#include <GL/glew.h>

#include <SFML/Window.hpp>
#include <SFML/OpenGL.hpp>
#include <SFML/Graphics.hpp>

#include <optional>
#include <fstream>
#include <sstream>
#include <vector>
#include <iostream>
#include <string>
#include <stdexcept>

// Лог шейдера
void ShaderLog(GLuint shader)
{
    GLint infologLen = 0;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
        std::cout << "Shader InfoLog:\n" << infoLog.data() << std::endl;
    }
}

// Лог программы
void ProgramLog(GLuint program)
{
    GLint infologLen = 0;
    glGetProgramiv(program, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetProgramInfoLog(program, infologLen, &charsWritten, infoLog.data());
        std::cout << "Program InfoLog:\n" << infoLog.data() << std::endl;
    }
}

// Загрузка файла в строку
std::string LoadFile(const std::string& path)
{
    std::ifstream file(path);
    if (!file.is_open())
        throw std::runtime_error("Cannot open file: " + path);

    std::stringstream buf;
    buf << file.rdbuf();
    return buf.str();
}

void makeRotX(float a, float m[9])
{
    float c = std::cos(a);
    float s = std::sin(a);

    m[0] = 1;  m[3] = 0;  m[6] = 0;
    m[1] = 0;  m[4] = c;  m[7] = -s;
    m[2] = 0;  m[5] = s;  m[8] = c;
}

void makeRotY(float a, float m[9])
{
    float c = std::cos(a);
    float s = std::sin(a);

    m[0] = c; m[3] = 0;  m[6] = s;
    m[1] = 0; m[4] = 1;  m[7] = 0;
    m[2] = -s; m[5] = 0;  m[8] = c;
}

void makeRotZ(float a, float m[9])
{
    float c = std::cos(a);
    float s = std::sin(a);

    m[0] = c;  m[3] = -s; m[6] = 0;
    m[1] = s;  m[4] = c; m[7] = 0;
    m[2] = 0;  m[5] = 0; m[8] = 1;
}

void mulMat3(const float A[9], const float B[9], float R[9])
{
    for (int c = 0; c < 3; ++c)
        for (int r = 0; r < 3; ++r)
            R[c * 3 + r] =
            A[0 * 3 + r] * B[c * 3 + 0] +
            A[1 * 3 + r] * B[c * 3 + 1] +
            A[2 * 3 + r] * B[c * 3 + 2];
}

int main()
{
    // Window
    sf::ContextSettings settings{};
    settings.depthBits = 24;
    settings.stencilBits = 8;
    settings.majorVersion = 3;
    settings.minorVersion = 3;

    sf::RenderWindow window(
        sf::VideoMode({ 800u, 600u }),
        "Lab 12 - Tetrahedron, Textured Cube, Gradient Circle"
    );
    window.setVerticalSyncEnabled(true);

    // GLEW
    glewExperimental = GL_TRUE;
    GLenum glewErr = glewInit();
    if (glewErr != GLEW_OK)
    {
        std::cerr << "GLEW init failed: " << glewGetErrorString(glewErr) << "\n";
        return -1;
    }
    glGetError();

    // Shaders
    std::string vertCode = LoadFile("shader.vert");
    std::string fragCode = LoadFile("shader.frag");

    const char* vertSrc = vertCode.c_str();
    const char* fragSrc = fragCode.c_str();

    GLuint vs = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs, 1, &vertSrc, nullptr);
    glCompileShader(vs);
    ShaderLog(vs);

    GLuint fs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fs, 1, &fragSrc, nullptr);
    glCompileShader(fs);
    ShaderLog(fs);

    GLuint program = glCreateProgram();
    glAttachShader(program, vs);
    glAttachShader(program, fs);
    glLinkProgram(program);
    ProgramLog(program);

    glDetachShader(program, vs);
    glDetachShader(program, fs);
    glDeleteShader(vs);
    glDeleteShader(fs);

    // Vertices data
    float tetraVertices[] = {
         0.000f,  0.500f,  0.000f,  1.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        -0.500f, -0.500f,  0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 0.0f,
         0.500f, -0.500f,  0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 0.0f,

         0.000f,  0.500f,  0.000f,  1.000f,  0.000f,  0.000f,  0.0f, 0.0f,
         0.500f, -0.500f,  0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 0.0f,
         0.000f, -0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  0.0f, 0.0f,

         0.000f,  0.500f,  0.000f,  1.000f,  0.000f,  0.000f,  0.0f, 0.0f,
         0.000f, -0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  0.0f, 0.0f,
        -0.500f, -0.500f,  0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 0.0f,

        -0.500f, -0.500f,  0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 0.0f,
         0.000f, -0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  0.0f, 0.0f,
         0.500f, -0.500f,  0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 0.0f,
    };

    float cubeVertices[] = {
        // front
        -0.500f, -0.500f, +0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 0.0f,
        +0.500f, -0.500f, +0.500f,  1.000f,  0.000f,  1.000f,  1.0f, 0.0f,
        +0.500f, +0.500f, +0.500f,  1.000f,  1.000f,  1.000f,  1.0f, 1.0f,
        -0.500f, -0.500f, +0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 0.0f,
        +0.500f, +0.500f, +0.500f,  1.000f,  1.000f,  1.000f,  1.0f, 1.0f,
        -0.500f, +0.500f, +0.500f,  0.000f,  1.000f,  1.000f,  0.0f, 1.0f,

        // back
        +0.500f, -0.500f, -0.500f,  1.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        -0.500f, -0.500f, -0.500f,  0.000f,  0.000f,  0.000f,  1.0f, 0.0f,
        -0.500f, +0.500f, -0.500f,  0.000f,  1.000f,  0.000f,  1.0f, 1.0f,
        +0.500f, -0.500f, -0.500f,  1.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        -0.500f, +0.500f, -0.500f,  0.000f,  1.000f,  0.000f,  1.0f, 1.0f,
        +0.500f, +0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  0.0f, 1.0f,

        // left
        -0.500f, -0.500f, +0.500f,  0.000f,  0.000f,  1.000f,  1.0f, 0.0f,
        -0.500f, -0.500f, -0.500f,  0.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        -0.500f, +0.500f, -0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 1.0f,
        -0.500f, -0.500f, +0.500f,  0.000f,  0.000f,  1.000f,  1.0f, 0.0f,
        -0.500f, +0.500f, -0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 1.0f,
        -0.500f, +0.500f, +0.500f,  0.000f,  1.000f,  1.000f,  1.0f, 1.0f,

        // right
        +0.500f, -0.500f, -0.500f,  1.000f,  0.000f,  0.000f,  1.0f, 0.0f,
        +0.500f, -0.500f, +0.500f,  1.000f,  0.000f,  1.000f,  0.0f, 0.0f,
        +0.500f, +0.500f, +0.500f,  1.000f,  1.000f,  1.000f,  0.0f, 1.0f,
        +0.500f, -0.500f, -0.500f,  1.000f,  0.000f,  0.000f,  1.0f, 0.0f,
        +0.500f, +0.500f, +0.500f,  1.000f,  1.000f,  1.000f,  0.0f, 1.0f,
        +0.500f, +0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  1.0f, 1.0f,

        // top
        -0.500f, +0.500f, +0.500f,  0.000f,  1.000f,  1.000f,  0.0f, 0.0f,
        +0.500f, +0.500f, +0.500f,  1.000f,  1.000f,  1.000f,  1.0f, 0.0f,
        +0.500f, +0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  1.0f, 1.0f,
        -0.500f, +0.500f, +0.500f,  0.000f,  1.000f,  1.000f,  0.0f, 0.0f,
        +0.500f, +0.500f, -0.500f,  1.000f,  1.000f,  0.000f,  1.0f, 1.0f,
        -0.500f, +0.500f, -0.500f,  0.000f,  1.000f,  0.000f,  0.0f, 1.0f,

        // bottom
        -0.500f, -0.500f, -0.500f,  0.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        +0.500f, -0.500f, -0.500f,  1.000f,  0.000f,  0.000f,  1.0f, 0.0f,
        +0.500f, -0.500f, +0.500f,  1.000f,  0.000f,  1.000f,  1.0f, 1.0f,
        -0.500f, -0.500f, -0.500f,  0.000f,  0.000f,  0.000f,  0.0f, 0.0f,
        +0.500f, -0.500f, +0.500f,  1.000f,  0.000f,  1.000f,  1.0f, 1.0f,
        -0.500f, -0.500f, +0.500f,  0.000f,  0.000f,  1.000f,  0.0f, 1.0f,
    };

    // VBO / VAO 
    GLuint vaoTetra = 0, vboTetra = 0;
    GLuint vaoCube = 0, vboCube = 0;

    GLsizei stride = 8 * sizeof(float);

    // Tetra
    glGenVertexArrays(1, &vaoTetra);
    glGenBuffers(1, &vboTetra);
    glBindVertexArray(vaoTetra);
    glBindBuffer(GL_ARRAY_BUFFER, vboTetra);
    glBufferData(GL_ARRAY_BUFFER, sizeof(tetraVertices), tetraVertices, GL_STATIC_DRAW);

    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, stride, (void*)0);
    glEnableVertexAttribArray(0);

    glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, stride, (void*)(3 * sizeof(float)));
    glEnableVertexAttribArray(1);

    glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, stride, (void*)(6 * sizeof(float)));
    glEnableVertexAttribArray(2);

    glBindVertexArray(0);

    // Cube
    glGenVertexArrays(1, &vaoCube);
    glGenBuffers(1, &vboCube);
    glBindVertexArray(vaoCube);
    glBindBuffer(GL_ARRAY_BUFFER, vboCube);
    glBufferData(GL_ARRAY_BUFFER, sizeof(cubeVertices), cubeVertices, GL_STATIC_DRAW);

    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, stride, (void*)0);
    glEnableVertexAttribArray(0);

    glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, stride, (void*)(3 * sizeof(float)));
    glEnableVertexAttribArray(1);

    glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, stride, (void*)(6 * sizeof(float)));
    glEnableVertexAttribArray(2);

    glBindVertexArray(0);

    // ---- CIRCLE ----
    std::vector<float> circleVertices;
    const int N = 256;
    circleVertices.reserve((N + 2) * 3);

    // center
    circleVertices.push_back(0.0f);
    circleVertices.push_back(0.0f);
    circleVertices.push_back(0.0f);

    // circle points as vec3 (z=0)
    for (int i = 0; i <= N; ++i)
    {
        float a = float(i) / float(N) * 2.0f * 3.14159265358979f;
        circleVertices.push_back(std::cos(a));
        circleVertices.push_back(std::sin(a));
        circleVertices.push_back(0.0f);
    }

    GLuint vaoCircle = 0, vboCircle = 0;
    glGenVertexArrays(1, &vaoCircle);
    glGenBuffers(1, &vboCircle);

    glBindVertexArray(vaoCircle);
    glBindBuffer(GL_ARRAY_BUFFER, vboCircle);
    glBufferData(GL_ARRAY_BUFFER, circleVertices.size() * sizeof(float), circleVertices.data(), GL_STATIC_DRAW);

    // position attribute only (location = 0)
    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(0);

    // don't enable attrib 1 and 2 here (we'll set them as constants during draw)
    glBindVertexArray(0);

    // ---- ТЕКСТУРЫ ДЛЯ КУБА ----
    GLuint textureId1 = 0;
    GLuint textureId2 = 0;

    // Первая текстура
    {
        sf::Image img;
        if (!img.loadFromFile("texture.png"))
        {
            std::cerr << "Failed to load texture.png\n";
        }
        else
        {
            glGenTextures(1, &textureId1);
            glBindTexture(GL_TEXTURE_2D, textureId1);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

            glTexImage2D(
                GL_TEXTURE_2D,
                0,
                GL_RGBA,
                static_cast<GLsizei>(img.getSize().x),
                static_cast<GLsizei>(img.getSize().y),
                0,
                GL_RGBA,
                GL_UNSIGNED_BYTE,
                img.getPixelsPtr()
            );
            glGenerateMipmap(GL_TEXTURE_2D);
            glBindTexture(GL_TEXTURE_2D, 0);
        }
    }

    {
        sf::Image img;
        if (!img.loadFromFile("texture2.png"))
        {
            std::cerr << "Failed to load texture2.png\n";
        }
        else
        {
            glGenTextures(1, &textureId2);
            glBindTexture(GL_TEXTURE_2D, textureId2);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

            glTexImage2D(
                GL_TEXTURE_2D,
                0,
                GL_RGBA,
                static_cast<GLsizei>(img.getSize().x),
                static_cast<GLsizei>(img.getSize().y),
                0,
                GL_RGBA,
                GL_UNSIGNED_BYTE,
                img.getPixelsPtr()
            );
            glGenerateMipmap(GL_TEXTURE_2D);
            glBindTexture(GL_TEXTURE_2D, 0);
        }
    }

    // Uniforms
    glUseProgram(program);
    GLint uOffsetLoc = glGetUniformLocation(program, "uOffset");
    GLint uColorMixLoc = glGetUniformLocation(program, "uColorMix");
    GLint uUseTextureLoc = glGetUniformLocation(program, "uUseTexture");
    GLint uTextureLoc = glGetUniformLocation(program, "uTexture");
    GLint uTexture2Loc = glGetUniformLocation(program, "uTexture2");
    GLint uTextureMixLoc = glGetUniformLocation(program, "uTextureMix");
    GLint uWorldRotLoc = glGetUniformLocation(program, "uWorldRot");
    GLint uCircleScaleLoc = glGetUniformLocation(program, "uCircleScale");
    GLint uRenderModeLoc = glGetUniformLocation(program, "uRenderMode"); // 0-default,1-circle

    if (uTextureLoc != -1)
        glUniform1i(uTextureLoc, 0);
    if (uTexture2Loc != -1)
        glUniform1i(uTexture2Loc, 1);

    glUseProgram(0);

    // OpenGL
    glEnable(GL_DEPTH_TEST);
    glClearColor(0.1f, 0.1f, 0.15f, 1.0f);

    // Control params
    float tetraOffset[3] = { 0.0f, 0.0f, 0.0f };
    float cubeOffset[3] = { 0.0f, 0.0f, 0.0f };

    float colorMix = 0.5f;
    float textureMix = 0.5f;   
    const float moveStep = 0.1f;
    const float rotStep = 5.0f * 3.14159265f / 180.0f;
    float tetraRotation[9] = {
        1,0,0,
        0,1,0,
        0,0,1
    };
    float cubeRotation[9] = {
        1,0,0,
        0,1,0,
        0,0,1
    };
    const float mixStep = 0.05f;

    float circleScale[2] = { 1.0f, 1.0f };

    int activeObject = 0; 
    bool isCubeActive = false;
    int cubeMode = 0; 

    std::cout << "Controls:\n"
        << "  1 - tetrahedron\n"
        << "  2 - cube\n"
        << "  3 - circle (gradient)\n"
        << "  TAB - switch cube mode (single texture / mixed textures)\n"
        << "  W/A/S/D, Q/E - move the active object along the X/Y/Z axes\n"
        << "  I/K - rotate around the X axis\n"
        << "  J/L - rotate around the Y axis\n"
        << "  U/O - rotate around the Z axis\n"
        << "  UP/DOWN - change the contribution of vertex color to the texture (for single texture mode)\n"
        << "  LEFT/RIGHT - change the mix between two textures (for mixed textures mode)\n"
        << "  Z/X - scale circle on X axis (+/-)\n"
        << "  C/V - scale circle on Y axis (+/-)\n"
        << "  ESC - exit\n";

    // Cycle
    while (window.isOpen())
    {
        // Events
        while (const std::optional<sf::Event> event = window.pollEvent())
        {
            if (event->is<sf::Event::Closed>())
            {
                window.close();
            }

            else if (const auto* resized = event->getIf<sf::Event::Resized>())
            {
                glViewport(
                    0,
                    0,
                    static_cast<GLsizei>(resized->size.x),
                    static_cast<GLsizei>(resized->size.y)
                );
            }

            else if (const auto* keyPressed = event->getIf<sf::Event::KeyPressed>())
            {
                using Key = sf::Keyboard::Key;

                float* activeOffset = (activeObject == 1) ? cubeOffset : tetraOffset;
                float* activeRotation = (activeObject == 1) ? cubeRotation : tetraRotation;

                switch (keyPressed->code)
                {
                case Key::Escape:
                    window.close();
                    break;

                case Key::Num1:
                    activeObject = 0;
                    std::cout << "Active: Tetra\n";
                    break;
                case Key::Num2:
                    activeObject = 1;
                    std::cout << "Active: Cube\n";
                    break;
                case Key::Num3:
                    activeObject = 2;
                    std::cout << "Active: Circle\n";
                    break;

                case Key::Tab:
                    if (activeObject == 1)
                    {
                        cubeMode = (cubeMode + 1) % 2;
                        std::cout << "Cube mode: " << (cubeMode == 0 ? "Single texture" : "Mixed textures") << "\n";
                    }
                    break;

                    // Position
                case Key::A: // -X
                    if (activeObject != 2) activeOffset[0] -= moveStep;
                    break;
                case Key::D: // +X
                    if (activeObject != 2) activeOffset[0] += moveStep;
                    break;
                case Key::W: // +Y
                    if (activeObject != 2) activeOffset[1] += moveStep;
                    break;
                case Key::S: // -Y
                    if (activeObject != 2) activeOffset[1] -= moveStep;
                    break;
                case Key::Q: // -Z
                    if (activeObject != 2) activeOffset[2] -= moveStep;
                    break;
                case Key::E: // +Z
                    if (activeObject != 2) activeOffset[2] += moveStep;
                    break;

                    // Rotation
                case Key::I: // +X
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotX(+rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }
                case Key::K: // -X
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotX(-rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }
                case Key::J: // +Y
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotY(+rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }
                case Key::L: // -Y
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotY(-rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }
                case Key::U: // +Z
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotZ(+rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }
                case Key::O: // -Z
                {
                    if (activeObject != 2)
                    {
                        float r[9], tmp[9];
                        makeRotZ(-rotStep, r);
                        mulMat3(r, activeRotation, tmp);
                        for (int i = 0; i < 9; ++i)
                            activeRotation[i] = tmp[i];
                    }
                    break;
                }

                // Color mix (для режима одной текстуры)
                case Key::Up:
                    if (activeObject == 1 && cubeMode == 0)
                    {
                        colorMix += mixStep;
                        if (colorMix > 1.0f) colorMix = 1.0f;
                        std::cout << "colorMix = " << colorMix << "\n";
                    }
                    break;
                case Key::Down:
                    if (activeObject == 1 && cubeMode == 0)
                    {
                        colorMix -= mixStep;
                        if (colorMix < 0.0f) colorMix = 0.0f;
                        std::cout << "colorMix = " << colorMix << "\n";
                    }
                    break;

                    // Texture mix (для режима двух текстур)
                case Key::Right:
                    if (activeObject == 1 && cubeMode == 1)
                    {
                        textureMix += mixStep;
                        if (textureMix > 1.0f) textureMix = 1.0f;
                        std::cout << "textureMix = " << textureMix << "\n";
                    }
                    break;
                case Key::Left:
                    if (activeObject == 1 && cubeMode == 1)
                    {
                        textureMix -= mixStep;
                        if (textureMix < 0.0f) textureMix = 0.0f;
                        std::cout << "textureMix = " << textureMix << "\n";
                    }
                    break;

                    // Circle scale controls
                case Key::Z:
                    if (activeObject == 2) { circleScale[0] += 0.1f; std::cout << "circleScale.x = " << circleScale[0] << "\n"; }
                    break;
                case Key::X:
                    if (activeObject == 2) { circleScale[0] -= 0.1f; if (circleScale[0] < 0.01f) circleScale[0] = 0.01f; std::cout << "circleScale.x = " << circleScale[0] << "\n"; }
                    break;
                case Key::C:
                    if (activeObject == 2) { circleScale[1] += 0.1f; std::cout << "circleScale.y = " << circleScale[1] << "\n"; }
                    break;
                case Key::V:
                    if (activeObject == 2) { circleScale[1] -= 0.1f; if (circleScale[1] < 0.01f) circleScale[1] = 0.01f; std::cout << "circleScale.y = " << circleScale[1] << "\n"; }
                    break;

                default:
                    break;
                }
            }
        }

        // Render
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        glUseProgram(program);

        // set common uniforms
        if (uRenderModeLoc != -1)
            glUniform1i(uRenderModeLoc, (activeObject == 2 ? 1 : 0));

        if (!(activeObject == 2))
        {
            // Tetra or Cube
            if (activeObject == 0)
            {
                glBindVertexArray(vaoTetra);

                if (uOffsetLoc != -1)
                    glUniform3fv(uOffsetLoc, 1, tetraOffset);
                if (uUseTextureLoc != -1)
                    glUniform1i(uUseTextureLoc, 0);
                if (uColorMixLoc != -1)
                    glUniform1f(uColorMixLoc, 0.0f);
                if (uWorldRotLoc != -1)
                    glUniformMatrix3fv(uWorldRotLoc, 1, GL_FALSE, tetraRotation);

                // ensure vertex attribs 1,2 are enabled (they are in VAO)
                glEnableVertexAttribArray(1);
                glEnableVertexAttribArray(2);

                glDrawArrays(GL_TRIANGLES, 0, 12);
            }
            else // cube
            {
                glBindVertexArray(vaoCube);

                if (uOffsetLoc != -1)
                    glUniform3fv(uOffsetLoc, 1, cubeOffset);
                if (uWorldRotLoc != -1)
                    glUniformMatrix3fv(uWorldRotLoc, 1, GL_FALSE, cubeRotation);

                // ensure vertex attribs 1,2 are enabled (they are in VAO)
                glEnableVertexAttribArray(1);
                glEnableVertexAttribArray(2);

                if (cubeMode == 0)
                {
                    // Режим одной текстуры с цветом
                    if (uColorMixLoc != -1)
                        glUniform1f(uColorMixLoc, colorMix);
                    if (uTextureMixLoc != -1)
                        glUniform1f(uTextureMixLoc, 0.0f); // Не используется в этом режиме

                    if (textureId1 != 0)
                    {
                        glActiveTexture(GL_TEXTURE0);
                        glBindTexture(GL_TEXTURE_2D, textureId1);
                        if (uUseTextureLoc != -1)
                            glUniform1i(uUseTextureLoc, 1);
                    }
                    else
                    {
                        if (uUseTextureLoc != -1)
                            glUniform1i(uUseTextureLoc, 0);
                    }
                }
                else
                {
                    // Режим двух смешанных текстур
                    if (uColorMixLoc != -1)
                        glUniform1f(uColorMixLoc, 0.0f); // Цвет не используется
                    if (uTextureMixLoc != -1)
                        glUniform1f(uTextureMixLoc, textureMix);

                    if (textureId1 != 0 && textureId2 != 0)
                    {
                        glActiveTexture(GL_TEXTURE0);
                        glBindTexture(GL_TEXTURE_2D, textureId1);
                        glActiveTexture(GL_TEXTURE1);
                        glBindTexture(GL_TEXTURE_2D, textureId2);
                        if (uUseTextureLoc != -1)
                            glUniform1i(uUseTextureLoc, 2); // Режим двух текстур
                    }
                    else
                    {
                        if (uUseTextureLoc != -1)
                            glUniform1i(uUseTextureLoc, 0);
                    }
                }

                glDrawArrays(GL_TRIANGLES, 0, 36);

                // Отвязываем текстуры
                glActiveTexture(GL_TEXTURE0);
                glBindTexture(GL_TEXTURE_2D, 0);
                glActiveTexture(GL_TEXTURE1);
                glBindTexture(GL_TEXTURE_2D, 0);
            }
        }
        else
        {
            // Draw circle
            glBindVertexArray(vaoCircle);

            // For circle: disable color/texcoord arrays and set constants
            glDisableVertexAttribArray(1); // color
            glDisableVertexAttribArray(2); // texcoord

            // set constant attribute values used by shader
            glVertexAttrib3f(1, 1.0f, 1.0f, 1.0f); // vColor fallback
            glVertexAttrib2f(2, 0.5f, 0.5f); // vTexCoord fallback base (will be overwritten in vertex shader using pos and uCircleScale)

            if (uOffsetLoc != -1)
            {
                float zero[3] = { 0.0f,0.0f,0.0f };
                glUniform3fv(uOffsetLoc, 1, zero);
            }
            if (uWorldRotLoc != -1)
            {
                float I[9] = { 1,0,0, 0,1,0, 0,0,1 };
                glUniformMatrix3fv(uWorldRotLoc, 1, GL_FALSE, I);
            }
            if (uUseTextureLoc != -1)
                glUniform1i(uUseTextureLoc, 0);

            if (uCircleScaleLoc != -1)
                glUniform2fv(uCircleScaleLoc, 1, circleScale);

            // draw triangle fan: center + N+1 vertices
            glDrawArrays(GL_TRIANGLE_FAN, 0, N + 2);

            // Re-enable attributes for other VAOs (so their VAOs can use them)
            // (They will be re-enabled when binding their VAOs but safe to enable)
            //glEnableVertexAttribArray(1);
            //glEnableVertexAttribArray(2);
        }

        glBindVertexArray(0);
        glUseProgram(0);

        window.display();

        GLenum errCode = glGetError();
        if (errCode != GL_NO_ERROR)
        {
            std::cerr << "OpenGL error: " << errCode << std::endl;
        }
    }

    // Clear
    glDeleteProgram(program);

    glDeleteBuffers(1, &vboTetra);
    glDeleteVertexArrays(1, &vaoTetra);

    glDeleteBuffers(1, &vboCube);
    glDeleteVertexArrays(1, &vaoCube);

    glDeleteBuffers(1, &vboCircle);
    glDeleteVertexArrays(1, &vaoCircle);

    if (textureId1 != 0)
        glDeleteTextures(1, &textureId1);
    if (textureId2 != 0)
        glDeleteTextures(1, &textureId2);

    return 0;
}
