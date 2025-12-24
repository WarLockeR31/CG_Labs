#include <fstream>
#include <GL/glew.h> 
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <sstream>
#include <vector>
#include <cmath>
#include <string>
#include <optional>

#pragma region MathHelpers
const float PI = 3.14159265359f;

void createPerspective(float fov, float aspect, float cnear, float cfar, float* matrix) {
    float tanHalfFov = tan(fov / 2.0f);
    std::fill_n(matrix, 16, 0.0f);
    matrix[0] = 1.0f / (aspect * tanHalfFov);
    matrix[5] = 1.0f / tanHalfFov;
    matrix[10] = -(cfar + cnear) / (cfar - cnear);
    matrix[11] = -1.0f;
    matrix[14] = -(2.0f * cfar * cnear) / (cfar - cnear);
}

void createIdentity(float* matrix) {
    std::fill_n(matrix, 16, 0.0f);
    matrix[0] = matrix[5] = matrix[10] = matrix[15] = 1.0f;
}

void createTranslation(float x, float y, float z, float* matrix) {
    createIdentity(matrix);
    matrix[12] = x; matrix[13] = y; matrix[14] = z;
}

void createRotationX(float angle, float* matrix) {
    createIdentity(matrix);
    matrix[5] = cos(angle); matrix[6] = -sin(angle);
    matrix[9] = sin(angle); matrix[10] = cos(angle);
}

void createRotationY(float angle, float* matrix) {
    createIdentity(matrix);
    matrix[0] = cos(angle); matrix[2] = sin(angle);
    matrix[8] = -sin(angle); matrix[10] = cos(angle);
}

void createScale(float sx, float sy, float sz, float* matrix) {
    createIdentity(matrix);
    matrix[0] = sx; matrix[5] = sy; matrix[10] = sz;
}

void multiplyMatrices(const float* a, const float* b, float* result) {
    float temp[16] = { 0 };
    for (int i = 0; i < 4; ++i) {
        for (int j = 0; j < 4; ++j) {
            temp[i * 4 + j] = 0;
            for (int k = 0; k < 4; ++k) temp[i * 4 + j] += a[i * 4 + k] * b[k * 4 + j];
        }
    }
    std::copy(temp, temp + 16, result);
}
#pragma endregion

#pragma region Obj Loader

struct MeshData {
    std::vector<float> data;
    int vertexCount;
};

MeshData LoadObj(const std::string& path) {
    std::ifstream file(path);
    if (!file.is_open()) throw std::runtime_error("Cannot open OBJ: " + path);

    std::vector<float> temp_v, temp_uv, temp_n;
    MeshData mesh;
    mesh.vertexCount = 0;
    std::string line;

    while (std::getline(file, line)) {
        std::stringstream ss(line);
        std::string prefix;
        ss >> prefix;

        if (prefix == "v") {
            float x, y, z; ss >> x >> y >> z;
            temp_v.insert(temp_v.end(), { x, y, z });
        }
        else if (prefix == "vt") {
            float u, v; ss >> u >> v;
            temp_uv.insert(temp_uv.end(), { u, v });
        }
        else if (prefix == "vn") {
            float nx, ny, nz; ss >> nx >> ny >> nz;
            temp_n.insert(temp_n.end(), { nx, ny, nz });
        }
        else if (prefix == "f") {
            for (int i = 0; i < 3; i++) {
                std::string vertexStr;
                ss >> vertexStr;

                size_t slash1 = vertexStr.find('/');
                size_t slash2 = vertexStr.find('/', slash1 + 1);

                int vIdx = std::stoi(vertexStr.substr(0, slash1)) - 1;
                int vtIdx = std::stoi(vertexStr.substr(slash1 + 1, slash2 - slash1 - 1)) - 1;
                int vnIdx = std::stoi(vertexStr.substr(slash2 + 1)) - 1;

                mesh.data.push_back(temp_v[vIdx * 3]);
                mesh.data.push_back(temp_v[vIdx * 3 + 1]);
                mesh.data.push_back(temp_v[vIdx * 3 + 2]);

                if (!temp_uv.empty()) {
                    mesh.data.push_back(temp_uv[vtIdx * 2]);
                    mesh.data.push_back(1.0f - temp_uv[vtIdx * 2 + 1]);
                }
                else { mesh.data.push_back(0); mesh.data.push_back(0); }

                if (!temp_n.empty()) {
                    mesh.data.push_back(temp_n[vnIdx * 3]);
                    mesh.data.push_back(temp_n[vnIdx * 3 + 1]);
                    mesh.data.push_back(temp_n[vnIdx * 3 + 2]);
                }
                else { mesh.data.insert(mesh.data.end(), { 0, 1, 0 }); }

                mesh.vertexCount++;
            }
        }
    }
    return mesh;
}
#pragma endregion

#pragma region Utils

std::string LoadFile(const std::string& path) {
    std::ifstream file(path);
    if (!file.is_open()) return "";
    std::stringstream buf; buf << file.rdbuf(); return buf.str();
}

void CheckShader(GLuint shader, const std::string& name) {
    GLint success; glGetShaderiv(shader, GL_COMPILE_STATUS, &success);
    if (!success) {
        char info[512]; glGetShaderInfoLog(shader, 512, NULL, info);
        std::cerr << name << " Compile Error: " << info << std::endl;
    }
}
#pragma endregion 

struct SceneObject {
    MeshData mesh;
    GLuint textureID;
    float x, y, z;
    float scale;
    float rotY;
};

int main() {
    sf::Window window(sf::VideoMode({ 1024, 768 }), "Lab 14: P-Phong, T-Toon, M-Minnaert (Velvet)");
    window.setVerticalSyncEnabled(true);

    glewExperimental = GL_TRUE; glewInit();
    glEnable(GL_DEPTH_TEST);

    std::string vCode = LoadFile("lighting.vert");
    std::string phongFCode = LoadFile("lighting.frag");
    std::string toonFCode = LoadFile("toon.frag");
    std::string minnaertFCode = LoadFile("minnaert.frag");

    if (vCode.empty() || phongFCode.empty() || toonFCode.empty() || minnaertFCode.empty()) {
        std::cerr << "Failed to load shaders. Ensure lighting.vert, lighting.frag, toon.frag, minnaert.frag exist." << std::endl;
        return -1;
    }

    const char* vSrc = vCode.c_str();
    const char* phongFSrc = phongFCode.c_str();
    const char* toonFSrc = toonFCode.c_str();
    const char* minnaertFSrc = minnaertFCode.c_str();

    GLuint vs = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs, 1, &vSrc, NULL); glCompileShader(vs); CheckShader(vs, "Vertex Shader");

    GLuint phongFs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(phongFs, 1, &phongFSrc, NULL); glCompileShader(phongFs); CheckShader(phongFs, "Phong FS");
    GLuint phongProg = glCreateProgram();
    glAttachShader(phongProg, vs); glAttachShader(phongProg, phongFs); glLinkProgram(phongProg);

    GLuint toonFs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(toonFs, 1, &toonFSrc, NULL); glCompileShader(toonFs); CheckShader(toonFs, "Toon FS");
    GLuint toonProg = glCreateProgram();
    glAttachShader(toonProg, vs); glAttachShader(toonProg, toonFs); glLinkProgram(toonProg);

    GLuint minnaertFs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(minnaertFs, 1, &minnaertFSrc, NULL); glCompileShader(minnaertFs); CheckShader(minnaertFs, "Minnaert FS");
    GLuint minnaertProg = glCreateProgram();
    glAttachShader(minnaertProg, vs); glAttachShader(minnaertProg, minnaertFs); glLinkProgram(minnaertProg);

    glDeleteShader(vs); glDeleteShader(phongFs); glDeleteShader(toonFs); glDeleteShader(minnaertFs);

    // Переменная режима: 0 - Phong, 1 - Toon, 2 - Minnaert
    int lightingModel = 0;

    std::vector<SceneObject> objects;
    struct ObjInfo { std::string name; float x, y, z; float s; float r; };
    std::vector<ObjInfo> sceneConfig = {
        {"Assets/house.obj",    0.0f, 0.0f, -10.0f,  3.0f, 0.0f},
        {"Assets/couch.obj",    0.0f, 0.0f, -5.0f,   1.2f, 0.0f},
        {"Assets/tvTable.obj", -3.0f, 0.0f, -8.0f,   1.0f, 0.5f},
        {"Assets/TV.obj",      -3.0f, 0.5f, -8.0f,   1.0f, 0.5f},
        {"Assets/freezer.obj",  -1.0f, 0.0f, -8.0f,   0.5f, -0.5f}
    };

    for (const auto& info : sceneConfig) {
        SceneObject obj;
        try { obj.mesh = LoadObj(info.name); }
        catch (...) {
            obj.mesh.data = { -1,-1,0, 0,0, 0,0,1,  1,-1,0, 1,0, 0,0,1,  0,1,0, 0.5,1, 0,0,1 }; obj.mesh.vertexCount = 3;
        }
        std::string textureFile = info.name.substr(0, info.name.find_last_of('.')) + ".png";

        glGenTextures(1, &obj.textureID); glBindTexture(GL_TEXTURE_2D, obj.textureID);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

        sf::Image img;
        if (img.loadFromFile(textureFile)) {
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
            glGenerateMipmap(GL_TEXTURE_2D);
        }
        else {
            unsigned char white[] = { 255, 255, 255, 255 };
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, 1, 1, 0, GL_RGBA, GL_UNSIGNED_BYTE, white);
        }
        obj.x = info.x; obj.y = info.y; obj.z = info.z; obj.scale = info.s; obj.rotY = info.r;
        objects.push_back(obj);
    }

    GLuint VBO, VAO;
    glGenVertexArrays(1, &VAO); glGenBuffers(1, &VBO);
    float projection[16]; createPerspective(1.047f, 1024.0f / 768.0f, 0.1f, 100.0f, projection);

    float viewTranslation[16], viewRotation[16], view[16];
    createTranslation(0.0f, -6.0f, -12.0f, viewTranslation);
    createRotationX(-25.0f * PI / 180.0f, viewRotation);
    multiplyMatrices(viewRotation, viewTranslation, view);

    sf::Vector3f pointLightPos(0.0f, 3.0f, -6.0f);
    sf::Vector3f spotLightPos(0.0f, 2.0f, 0.0f);
    bool isDirLightOn = true, isPointLightOn = true, isSpotLightOn = true;
    sf::Clock deltaClock;

    while (window.isOpen()) {
        float deltaTime = deltaClock.restart().asSeconds();
        float moveSpeed = 10.0f * deltaTime;

        while (const std::optional event = window.pollEvent()) {
            if (event->is<sf::Event::Closed>()) window.close();
            if (const auto* r = event->getIf<sf::Event::Resized>()) {
                glViewport(0, 0, r->size.x, r->size.y);
                createPerspective(1.047f, (float)r->size.x / r->size.y, 0.1f, 100.0f, projection);
            }
            if (const auto* k = event->getIf<sf::Event::KeyPressed>()) {
                if (k->code == sf::Keyboard::Key::Num1) isDirLightOn = !isDirLightOn;
                if (k->code == sf::Keyboard::Key::Num2) isPointLightOn = !isPointLightOn;
                if (k->code == sf::Keyboard::Key::Num3) isSpotLightOn = !isSpotLightOn;

                if (k->code == sf::Keyboard::Key::P) { lightingModel = 0; std::cout << "Model: Phong\n"; }
                if (k->code == sf::Keyboard::Key::T) { lightingModel = 1; std::cout << "Model: Toon\n"; }
                if (k->code == sf::Keyboard::Key::M) { lightingModel = 2; std::cout << "Model: Minnaert\n"; }
            }
        }

        // Управление светом
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::W)) spotLightPos.z -= moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::S)) spotLightPos.z += moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::A)) spotLightPos.x -= moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::D)) spotLightPos.x += moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::Up))    pointLightPos.z -= moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::Down))  pointLightPos.z += moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::Left))  pointLightPos.x -= moveSpeed;
        if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::Right)) pointLightPos.x += moveSpeed;

        glClearColor(0.1f, 0.1f, 0.15f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        GLuint currentProgram = phongProg;
        if (lightingModel == 1) currentProgram = toonProg;
        if (lightingModel == 2) currentProgram = minnaertProg;

        glUseProgram(currentProgram);

        GLint modelLoc = glGetUniformLocation(currentProgram, "model");
        GLint viewLoc = glGetUniformLocation(currentProgram, "view");
        GLint projLoc = glGetUniformLocation(currentProgram, "projection");
        GLint viewPosLoc = glGetUniformLocation(currentProgram, "viewPos");

        float dirInt = isDirLightOn ? 1.0f : 0.0f;
        glUniform3f(glGetUniformLocation(currentProgram, "dirLight.direction"), 1.f, -1.0f, 0.f);
        glUniform3f(glGetUniformLocation(currentProgram, "dirLight.ambient"), 0.05f * dirInt, 0.05f * dirInt, 0.05f * dirInt);
        glUniform3f(glGetUniformLocation(currentProgram, "dirLight.diffuse"), 0.4f * dirInt, 0.4f * dirInt, 0.4f * dirInt);
        glUniform3f(glGetUniformLocation(currentProgram, "dirLight.specular"), 0.5f * dirInt, 0.5f * dirInt, 0.5f * dirInt);

        float pInt = isPointLightOn ? 1.0f : 0.0f;
        glUniform3f(glGetUniformLocation(currentProgram, "pointLight.position"), pointLightPos.x, pointLightPos.y, pointLightPos.z);
        glUniform3f(glGetUniformLocation(currentProgram, "pointLight.ambient"), 0.05f * pInt, 0.05f * pInt, 0.05f * pInt);
        glUniform3f(glGetUniformLocation(currentProgram, "pointLight.diffuse"), 0.8f * pInt, 0.6f * pInt, 0.4f * pInt);
        glUniform3f(glGetUniformLocation(currentProgram, "pointLight.specular"), 1.0f * pInt, 1.0f * pInt, 1.0f * pInt);
        glUniform1f(glGetUniformLocation(currentProgram, "pointLight.constant"), 1.0f);
        glUniform1f(glGetUniformLocation(currentProgram, "pointLight.linear"), 0.09f);
        glUniform1f(glGetUniformLocation(currentProgram, "pointLight.quadratic"), 0.032f);

        float sInt = isSpotLightOn ? 1.0f : 0.0f;
        glUniform3f(glGetUniformLocation(currentProgram, "spotLight.position"), spotLightPos.x, spotLightPos.y, spotLightPos.z);
        glUniform3f(glGetUniformLocation(currentProgram, "spotLight.direction"), 0.0f, 0.0f, -1.0f);
        glUniform3f(glGetUniformLocation(currentProgram, "spotLight.ambient"), 0.0f, 0.0f, 0.0f);
        glUniform3f(glGetUniformLocation(currentProgram, "spotLight.diffuse"), 1.0f * sInt, 1.0f * sInt, 1.0f * sInt);
        glUniform3f(glGetUniformLocation(currentProgram, "spotLight.specular"), 1.0f * sInt, 1.0f * sInt, 1.0f * sInt);
        glUniform1f(glGetUniformLocation(currentProgram, "spotLight.constant"), 1.0f);
        glUniform1f(glGetUniformLocation(currentProgram, "spotLight.linear"), 0.09f);
        glUniform1f(glGetUniformLocation(currentProgram, "spotLight.quadratic"), 0.032f);
        glUniform1f(glGetUniformLocation(currentProgram, "spotLight.cutOff"), cos(15.5f * PI / 180.0f));
        glUniform1f(glGetUniformLocation(currentProgram, "spotLight.outerCutOff"), cos(20.5f * PI / 180.0f));

        glUniform1f(glGetUniformLocation(currentProgram, "material.shininess"), 32.0f);
        glUniformMatrix4fv(viewLoc, 1, GL_FALSE, view);
        glUniformMatrix4fv(projLoc, 1, GL_FALSE, projection);
        glUniform3f(viewPosLoc, 0.0f, 6.0f, 12.0f);

        for (auto& obj : objects) {
            glBindVertexArray(VAO); glBindBuffer(GL_ARRAY_BUFFER, VBO);
            glBufferData(GL_ARRAY_BUFFER, obj.mesh.data.size() * sizeof(float), obj.mesh.data.data(), GL_STATIC_DRAW);
            glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)0); glEnableVertexAttribArray(0);
            glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)(3 * sizeof(float))); glEnableVertexAttribArray(1);
            glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)(5 * sizeof(float))); glEnableVertexAttribArray(2);

            glActiveTexture(GL_TEXTURE0); glBindTexture(GL_TEXTURE_2D, obj.textureID);
            glUniform1i(glGetUniformLocation(currentProgram, "material.diffuse"), 0);

            float model[16], temp[16], trans[16], rot[16], sc[16];
            createTranslation(obj.x, obj.y, obj.z, trans);
            createRotationY(obj.rotY, rot);
            createScale(obj.scale, obj.scale, obj.scale, sc);
            multiplyMatrices(rot, sc, temp); multiplyMatrices(trans, temp, model);
            glUniformMatrix4fv(modelLoc, 1, GL_FALSE, model);

            glDrawArrays(GL_TRIANGLES, 0, obj.mesh.vertexCount);
        }
        window.display();
    }
    return 0;
}