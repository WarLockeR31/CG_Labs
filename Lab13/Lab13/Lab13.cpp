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

#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

#pragma region MathHelpers
// ----------------------------------------- Math helpers -----------------------------------------
struct Vec3 {
    float x, y, z;
};

Vec3 normalize(Vec3 v) {
    float length = sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
    if (length == 0) return { 0, 0, 0 };
    return { v.x / length, v.y / length, v.z / length };
}

Vec3 cross(Vec3 a, Vec3 b) {
    return {
        a.y * b.z - a.z * b.y,
        a.z * b.x - a.x * b.z,
        a.x * b.y - a.y * b.x
    };
}

Vec3 subtract(Vec3 a, Vec3 b) {
    return { a.x - b.x, a.y - b.y, a.z - b.z };
}

Vec3 add(Vec3 a, Vec3 b) {
    return { a.x + b.x, a.y + b.y, a.z + b.z };
}

Vec3 multiply(Vec3 v, float s) {
    return { v.x * s, v.y * s, v.z * s };
}

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
    matrix[12] = x;
    matrix[13] = y;
    matrix[14] = z;
}

void createRotationX(float angle, float* matrix) {
    createIdentity(matrix);
    matrix[5] = cos(angle);
    matrix[6] = -sin(angle);
    matrix[9] = sin(angle);
    matrix[10] = cos(angle);
}

void createRotationY(float angle, float* matrix) {
    createIdentity(matrix);
    matrix[0] = cos(angle);
    matrix[2] = sin(angle);
    matrix[8] = -sin(angle);
    matrix[10] = cos(angle);
}

void multiplyMatrices(const float* a, const float* b, float* result) {
    float temp[16] = { 0 };
    for (int i = 0; i < 4; ++i) {
        for (int j = 0; j < 4; ++j) {
            temp[i * 4 + j] = 0;
            for (int k = 0; k < 4; ++k) {
                temp[i * 4 + j] += a[i * 4 + k] * b[k * 4 + j];
            }
        }
    }
    std::copy(temp, temp + 16, result);
}

void createScale(float sx, float sy, float sz, float* matrix) {
    createIdentity(matrix);
    matrix[0] = sx;
    matrix[5] = sy;
    matrix[10] = sz;
}

void createLookAt(Vec3 eye, Vec3 center, Vec3 up, float* matrix) {
    Vec3 f = normalize(subtract(center, eye)); // Forward
    Vec3 s = normalize(cross(f, up));          // Right
    Vec3 u = cross(s, f);                      // Up

    createIdentity(matrix);
    matrix[0] = s.x;  matrix[4] = s.y;  matrix[8] = s.z;
    matrix[1] = u.x;  matrix[5] = u.y;  matrix[9] = u.z;
    matrix[2] = -f.x; matrix[6] = -f.y; matrix[10] = -f.z;

    matrix[12] = -(s.x * eye.x + s.y * eye.y + s.z * eye.z);
    matrix[13] = -(u.x * eye.x + u.y * eye.y + u.z * eye.z);
    matrix[14] = (f.x * eye.x + f.y * eye.y + f.z * eye.z);
}
#pragma endregion

#pragma region MeshData
// ----------------------------------------- Mesh Data -----------------------------------------
struct MeshData {
    std::vector<float> data; // x, y, z, u, v
    int vertexCount;
};

// v, vt и f
MeshData LoadObj(const std::string& path) {
    std::ifstream file(path);
    if (!file.is_open()) throw std::runtime_error("Cannot open OBJ: " + path);

    std::vector<float> temp_vertices; // x,y,z
    std::vector<float> temp_uvs;      // u,v
    MeshData mesh;
    mesh.vertexCount = 0;

    std::string line;
    while (std::getline(file, line)) {
        std::stringstream ss(line);
        std::string prefix;
        ss >> prefix;

        if (prefix == "v") {
            float x, y, z;
            ss >> x >> y >> z;
            temp_vertices.push_back(x);
            temp_vertices.push_back(y);
            temp_vertices.push_back(z);
        }
        else if (prefix == "vt") {
            float u, v;
            ss >> u >> v;
            temp_uvs.push_back(u);
            temp_uvs.push_back(v);
        }
        else if (prefix == "f") {
            // v1/vt1/vn1 v2/vt2/vn2
            std::string vertexStr;
            for (int i = 0; i < 3; i++) {
                ss >> vertexStr;

                // index/uvIndex/normIndex
                size_t firstSlash = vertexStr.find('/');
                size_t secondSlash = vertexStr.find('/', firstSlash + 1);

                std::string vIdxStr = vertexStr.substr(0, firstSlash);
                std::string vtIdxStr = vertexStr.substr(firstSlash + 1, secondSlash - firstSlash - 1);

                int vIdx = std::stoi(vIdxStr) - 1;
                int vtIdx = std::stoi(vtIdxStr) - 1;

                // Verticees coords
                mesh.data.push_back(temp_vertices[vIdx * 3]);
                mesh.data.push_back(temp_vertices[vIdx * 3 + 1]);
                mesh.data.push_back(temp_vertices[vIdx * 3 + 2]);

                // UV Coords
                if (!temp_uvs.empty()) {
                    mesh.data.push_back(temp_uvs[vtIdx * 2]);
                    mesh.data.push_back(1.0f - temp_uvs[vtIdx * 2 + 1]);
                }
                else {
                    mesh.data.push_back(0.0f); mesh.data.push_back(0.0f);
                }
                mesh.vertexCount++;
            }
        }
    }
    return mesh;
}
#pragma endregion

#pragma region Helpers
// ----------------------------------------- Helpers -----------------------------------------
void ShaderLog(GLuint shader) {
    GLint infologLen = 0;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1) {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
        std::cout << "Shader InfoLog: " << infoLog.data() << '\n';
    }
}

void ProgramLog(GLuint program) {
    GLint infologLen = 0;
    glGetProgramiv(program, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1) {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetProgramInfoLog(program, infologLen, &charsWritten, infoLog.data());
        std::cout << "Program InfoLog: " << infoLog.data() << '\n';
    }
}

std::string LoadFile(const std::string& path) {
    std::ifstream file(path);
    if (!file.is_open()) throw std::runtime_error("Cannot open file: " + path);
    std::stringstream buf;
    buf << file.rdbuf();
    return buf.str();
}
#pragma endregion

// Структура для небесного тела
struct CelestialBody {
    float orbitRadius;     // Радиус орбиты
    float orbitSpeed;      // Скорость вращения по орбите
    float rotationSpeed;   // Скорость вращения вокруг своей оси
    float scale;           // Масштаб объекта
    float orbitAngle;      // Текущий угол на орбите
    float rotationAngle;   // Текущий угол вращения
    float orbitTilt;       // Наклон орбиты (для разнообразия)
};

struct Camera {
    Vec3 position;
    Vec3 front;
    Vec3 up;
    Vec3 right;
    Vec3 worldUp;

    float yaw;
    float pitch;

    float moveSpeed;
    float mouseSensitivity;

    Camera(Vec3 pos) {
        position = pos;
        worldUp = { 0.0f, 1.0f, 0.0f };
        yaw = -90.0f; 
        pitch = 0.0f;
        moveSpeed = 10.0f;
        mouseSensitivity = 0.1f;
        updateVectors();
    }

    void updateVectors() {
        Vec3 newFront;
        newFront.x = cos(yaw * M_PI / 180.0f) * cos(pitch * M_PI / 180.0f);
        newFront.y = sin(pitch * M_PI / 180.0f);
        newFront.z = sin(yaw * M_PI / 180.0f) * cos(pitch * M_PI / 180.0f);
        front = normalize(newFront);

        right = normalize(cross(front, worldUp));
        up = normalize(cross(right, front));
    }

    void processMouse(float xoffset, float yoffset) {
        xoffset *= mouseSensitivity;
        yoffset *= mouseSensitivity;

        yaw += xoffset;
        pitch -= yoffset; 

        if (pitch > 89.0f) pitch = 89.0f;
        if (pitch < -89.0f) pitch = -89.0f;

        updateVectors();
    }

    void getViewMatrix(float* matrix) {
        createLookAt(position, add(position, front), up, matrix);
    }
};

int main()
{
    // Window settings
    sf::ContextSettings settings;
    settings.depthBits = 24;
    settings.stencilBits = 8;
    settings.majorVersion = 3;
    settings.minorVersion = 3;

    sf::VideoMode mode({ 800, 600 });
    sf::RenderWindow window(
        mode,
        "Solar System Simulation",
        sf::Style::Default,
        sf::State::Windowed,
        settings);
    window.setVerticalSyncEnabled(true);

    window.setMouseCursorVisible(false);
    bool mouseFocused = true; 

    glewExperimental = GL_TRUE;
    if (glewInit() != GLEW_OK) {
        std::cerr << "GLEW init failed\n";
        return -1;
    }

    // Depth test
    glEnable(GL_DEPTH_TEST);

    // Shaders
    std::string vertexCode = LoadFile("shader.vert");
    std::string fragmentCode = LoadFile("shader.frag");
    const char* vSrc = vertexCode.c_str();
    const char* fSrc = fragmentCode.c_str();

    GLuint vs = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs, 1, &vSrc, nullptr);
    glCompileShader(vs);
    ShaderLog(vs);

    GLuint fs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fs, 1, &fSrc, nullptr);
    glCompileShader(fs);
    ShaderLog(fs);

    GLuint program = glCreateProgram();
    glAttachShader(program, vs);
    glAttachShader(program, fs);
    glLinkProgram(program);
    ProgramLog(program);

    glDeleteShader(vs);
    glDeleteShader(fs);

    // Load data in memory (1 time)
    MeshData mesh;
    try {
        mesh = LoadObj("model.obj");
        std::cout << "Model loaded: " << mesh.vertexCount << " vertices." << std::endl;
    }
    catch (const std::exception& e) {
        std::cerr << "Error loading OBJ: " << e.what() << "\n";
        mesh.data = { -0.5f,-0.5f,0.0f, 0.0f,0.0f,  0.5f,-0.5f,0.0f, 1.0f,0.0f,  0.0f,0.5f,0.0f, 0.5f,1.0f };
        mesh.vertexCount = 3;
    }

    GLuint VBO, VAO;
    glGenVertexArrays(1, &VAO);
    glGenBuffers(1, &VBO);

    glBindVertexArray(VAO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, mesh.data.size() * sizeof(float), mesh.data.data(), GL_STATIC_DRAW);

    // Attributes
    GLint posLoc = glGetAttribLocation(program, "aPos");
    GLint uvLoc = glGetAttribLocation(program, "aTexCoord");

    glVertexAttribPointer(posLoc, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(posLoc);

    glVertexAttribPointer(uvLoc, 2, GL_FLOAT, GL_FALSE, 5 * sizeof(float), (void*)(3 * sizeof(float)));
    glEnableVertexAttribArray(uvLoc);

    // Texture load
    GLuint textureID;
    glGenTextures(1, &textureID);
    glBindTexture(GL_TEXTURE_2D, textureID);

    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

    sf::Image img;
    if (img.loadFromFile("texture.png")) {
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
        glGenerateMipmap(GL_TEXTURE_2D);
    }
    else {
        unsigned char defaultTexture[] = { 255, 0, 0, 255, 0, 255, 0, 255, 0, 0, 255, 255, 255, 255, 0, 255 };
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, 2, 2, 0, GL_RGBA, GL_UNSIGNED_BYTE, defaultTexture);
    }

    // UNIFORMS
    GLint modelLoc = glGetUniformLocation(program, "model");
    GLint viewLoc = glGetUniformLocation(program, "view");
    GLint projLoc = glGetUniformLocation(program, "projection");
    GLint texLoc = glGetUniformLocation(program, "texture1");

    // Projection matrix
    float projection[16];
    createPerspective(1.047f, 800.0f / 600.0f, 0.1f, 100.0f, projection);

    Camera camera({ 0.0f, 5.0f, 20.0f });

    std::vector<CelestialBody> bodies(6);
    bodies[0] = { 0.0f, 0.0f, 0.02f, 2.0f, 0.0f, 0.0f, 0.0f }; // Солнце
    bodies[1] = { 3.0f, 0.4f, 0.05f, 0.4f, 0.0f, 0.0f, 0.1f };
    bodies[2] = { 5.0f, 0.3f, 0.04f, 0.6f, 0.0f, 0.0f, 0.2f };
    bodies[3] = { 7.0f, 0.25f, 0.03f, 0.5f, 0.0f, 0.0f, 0.15f };
    bodies[4] = { 9.0f, 0.2f, 0.02f, 0.7f, 0.0f, 0.0f, 0.25f };
    bodies[5] = { 12.0f, 0.15f, 0.01f, 0.8f, 0.0f, 0.0f, 0.3f };

    sf::Clock clock;

    sf::Vector2i centerWindow(400, 300);
    sf::Mouse::setPosition(centerWindow, window);

    while (window.isOpen())
    {
        while (const std::optional event = window.pollEvent())
        {
            if (event->is<sf::Event::Closed>())
                window.close();

            if (const auto* resized = event->getIf<sf::Event::Resized>()) {
                glViewport(0, 0, resized->size.x, resized->size.y);
                createPerspective(1.047f, (float)resized->size.x / resized->size.y, 0.1f, 100.0f, projection);
                centerWindow = { (int)resized->size.x / 2, (int)resized->size.y / 2 };
            }
            if (const auto* keyEvent = event->getIf<sf::Event::KeyPressed>()) {
                if (keyEvent->code == sf::Keyboard::Key::Escape) {
                    mouseFocused = !mouseFocused;
                    window.setMouseCursorVisible(!mouseFocused);
                }
            }
        }

        float deltaTime = clock.restart().asSeconds();

        if (mouseFocused) {
            float velocity = camera.moveSpeed * deltaTime;

            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::W))
                camera.position = add(camera.position, multiply(camera.front, velocity));
            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::S))
                camera.position = subtract(camera.position, multiply(camera.front, velocity));

            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::D))
                camera.position = add(camera.position, multiply(camera.right, velocity));
            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::A))
                camera.position = subtract(camera.position, multiply(camera.right, velocity));

            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::Space))
                camera.position = add(camera.position, multiply(camera.worldUp, velocity)); 
            if (sf::Keyboard::isKeyPressed(sf::Keyboard::Key::LShift))
                camera.position = subtract(camera.position, multiply(camera.worldUp, velocity));

            sf::Vector2i mousePos = sf::Mouse::getPosition(window);
            float xOffset = (float)(mousePos.x - centerWindow.x);
            float yOffset = (float)(mousePos.y - centerWindow.y);

            if (window.hasFocus()) {
                sf::Mouse::setPosition(centerWindow, window);
                camera.processMouse(xOffset, yOffset);
            }
        }

        for (auto& body : bodies) {
            body.orbitAngle += body.orbitSpeed * deltaTime;
            body.rotationAngle += body.rotationSpeed * deltaTime;

            if (body.orbitAngle > 2 * M_PI) body.orbitAngle -= 2 * M_PI;
            if (body.rotationAngle > 2 * M_PI) body.rotationAngle -= 2 * M_PI;
        }

        glClearColor(0.0f, 0.0f, 0.1f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        glUseProgram(program);

        glActiveTexture(GL_TEXTURE0);
        glBindTexture(GL_TEXTURE_2D, textureID);
        glUniform1i(texLoc, 0);

        // --- CAMERA UPDATE: Получаем матрицу вида из камеры ---
        float view[16];
        camera.getViewMatrix(view);

        glUniformMatrix4fv(projLoc, 1, GL_FALSE, projection);
        glUniformMatrix4fv(viewLoc, 1, GL_FALSE, view);

        glBindVertexArray(VAO);

        for (int i = 0; i < bodies.size(); i++) {
            float model[16];
            float temp[16];
            float finalModel[16];

            createIdentity(model);

            if (i > 0) {
                float orbitMatrix[16];
                createRotationY(bodies[i].orbitAngle, orbitMatrix);

                float orbitTiltMatrix[16];
                createRotationX(bodies[i].orbitTilt, orbitTiltMatrix);

                float translationMatrix[16];
                createTranslation(bodies[i].orbitRadius, 0.0f, 0.0f, translationMatrix);

                multiplyMatrices(orbitTiltMatrix, orbitMatrix, temp);
                multiplyMatrices(temp, translationMatrix, model);
            }

            float rotationMatrix[16];
            createRotationY(bodies[i].rotationAngle, rotationMatrix);
            multiplyMatrices(model, rotationMatrix, temp);

            float scaleMatrix[16];
            createScale(bodies[i].scale, bodies[i].scale, bodies[i].scale, scaleMatrix);
            multiplyMatrices(temp, scaleMatrix, finalModel);

            glUniformMatrix4fv(modelLoc, 1, GL_FALSE, finalModel);
            glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount);
        }

        glBindVertexArray(0);
        window.display();
    }

    glDeleteVertexArrays(1, &VAO);
    glDeleteBuffers(1, &VBO);
    glDeleteProgram(program);

    return 0;
}