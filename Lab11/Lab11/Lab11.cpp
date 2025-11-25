#include <fstream>
#include <GL/glew.h> 
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <sstream>
#include <vector>

enum class Figure
{
    Quad,
    Fan,
    Pentagon,
    Count
};

float quadVertices[] = {
    //   x       y       r   g   b
    -0.3f, -0.3f,       0.f, 1.f, 0.f,
     0.3f, -0.3f,       0.f, 1.f, 0.f,
    -0.3f,  0.3f,       0.f, 1.f, 0.f,
     0.3f,  0.3f,       0.f, 1.f, 0.f
};

float fanVertices[] = {
     0.0f,  0.0f,       1.f, 0.f, 0.f,
     0.433f,  0.250f,   1.f, 0.f, 0.f,
     0.250f,  0.433f,   1.f, 0.f, 0.f,
     0.000f,  0.500f,   1.f, 0.f, 0.f,
    -0.250f,  0.433f,   1.f, 0.f, 0.f,
    -0.433f,  0.250f,   1.f, 0.f, 0.f
};

float pentagonVertices[] = {
    0.0f,   0.0f,       0.f, 0.f, 1.f,
    0.0f,   0.4f,       0.f, 0.f, 1.f,
    0.380f, 0.124f,     0.f, 0.f, 1.f,
    0.235f,-0.324f,     0.f, 0.f, 1.f,
   -0.235f,-0.324f,     0.f, 0.f, 1.f,
   -0.380f, 0.124f,     0.f, 0.f, 1.f,
    0.0f,   0.4f,       0.f, 0.f, 1.f
};

Figure next(Figure s)
{
    using U = std::underlying_type_t<Figure>;
    U val = static_cast<U>(s);
    val = (val + 1) % static_cast<U>(Figure::Count);
    return static_cast<Figure>(val);
}

void ShaderLog(GLuint shader)
{
    GLint infologLen = 0;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
        std::cout << "Shader InfoLog: " << infoLog.data() << std::endl;
    }
}

void ProgramLog(GLuint program)
{
    GLint infologLen = 0;
    glGetProgramiv(program, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        std::vector<char> infoLog(infologLen);
        GLsizei charsWritten = 0;
        glGetProgramInfoLog(program, infologLen, &charsWritten, infoLog.data());
        std::cout << "Program InfoLog: " << infoLog.data() << std::endl;
    }
}

std::string LoadFile(const std::string& path)
{
    std::ifstream file(path);
    if (!file.is_open())
        throw std::runtime_error("Cannot open file: " + path);

    std::stringstream buf;
    buf << file.rdbuf();
    return buf.str();
}

int main()
{
    // Window and OpenGL context
    sf::ContextSettings settings;
    settings.depthBits = 24;
    settings.stencilBits = 8;
    settings.majorVersion = 3;
    settings.minorVersion = 3;

    sf::VideoMode mode({ 800, 600 });
    sf::RenderWindow window(
        mode,
        "SFML + OpenGL",
        sf::Style::Default,
        sf::State::Windowed,
        settings
    );
    window.setVerticalSyncEnabled(true);

    // Initialize OpenGL function loader (GLEW)
    glewExperimental = GL_TRUE;
    GLenum err = glewInit();
    if (err != GLEW_OK)
    {
        std::cerr << "GLEW init failed: " << glewGetErrorString(err) << "\n";
        return -1;
    }
    std::cout << "GLEW init OK\n";

    // Shaders source
    std::string vertexCode = LoadFile("shader.vert");
    std::string fragmentCode = LoadFile("shader.frag");

    const char* vertexSrc = vertexCode.c_str();
    const char* fragmentSrc = fragmentCode.c_str();

    // Compile shaders
    GLuint vs = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vs, 1, &vertexSrc, nullptr);
    glCompileShader(vs);
    ShaderLog(vs);

    GLuint fs = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fs, 1, &fragmentSrc, nullptr);
    glCompileShader(fs);
    ShaderLog(fs);

    // Create and linking program
    GLuint program = glCreateProgram();
    glAttachShader(program, vs);
    glAttachShader(program, fs);
    glLinkProgram(program);
    ProgramLog(program);

    glDetachShader(program, vs);
    glDetachShader(program, fs);
    glDeleteShader(vs);
    glDeleteShader(fs);

    // VBO + VAO 
    GLuint VBOs[3];
    GLuint VAOs[3];
    glGenBuffers(3, VBOs);
    glGenVertexArrays(3, VAOs);

    // Attributes
    GLint posLoc = glGetAttribLocation(program, "aPos");
    GLint colorLoc = glGetAttribLocation(program, "aColor");

    if (posLoc == -1 || colorLoc == -1)
    {
        std::cerr << "Attribute not found in shader\n";
    }

    float* vertexData[3] = { quadVertices, fanVertices, pentagonVertices };
    GLsizeiptr vertexSizes[3] = {
        sizeof(quadVertices),
        sizeof(fanVertices),
        sizeof(pentagonVertices)
    };

    for (int i = 0; i < 3; ++i)
    {
        glBindVertexArray(VAOs[i]);
        glBindBuffer(GL_ARRAY_BUFFER, VBOs[i]);
        glBufferData(GL_ARRAY_BUFFER, vertexSizes[i], vertexData[i], GL_STATIC_DRAW);

        glVertexAttribPointer(posLoc, 2, GL_FLOAT, GL_FALSE,
            5 * sizeof(float), (void*)0);
        glEnableVertexAttribArray(posLoc);

        glVertexAttribPointer(colorLoc, 3, GL_FLOAT, GL_FALSE,
            5 * sizeof(float), (void*)(2 * sizeof(float)));
        glEnableVertexAttribArray(colorLoc);
    }

    glBindVertexArray(0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // >>> ЕДИНСТВЕННОЕ ДОБАВЛЕНИЕ: uniform location <<<
    GLint colorUniformLoc = glGetUniformLocation(program, "uColor");
    if (colorUniformLoc == -1)
    {
        std::cerr << "Warning: uniform 'uColor' not found in fragment shader.\n";
    }

    Figure currentFigure = Figure::Quad;

    // Main cycle
    while (window.isOpen())
    {
        while (const std::optional event = window.pollEvent())
        {
            if (event->is<sf::Event::Closed>())
                window.close();

            if (const auto* keyPressed = event->getIf<sf::Event::KeyPressed>())
            {
                switch (keyPressed->code)
                {
                case sf::Keyboard::Key::Num1:
                    currentFigure = next(currentFigure);
                    break;
                default:
                    break;
                }
            }
        }

        glClear(GL_COLOR_BUFFER_BIT);
        glUseProgram(program);

        // >>> УСТАНОВКА uniform-цвета перед отрисовкой каждой фигуры <<<
        switch (currentFigure)
        {
        case Figure::Quad:
            glUniform3f(colorUniformLoc, 0.0f, 1.0f, 0.0f); // green
            glBindVertexArray(VAOs[0]);
            glDrawArrays(GL_TRIANGLE_STRIP, 0, 4);
            break;

        case Figure::Fan:
            glUniform3f(colorUniformLoc, 1.0f, 0.0f, 0.0f); // red
            glBindVertexArray(VAOs[1]);
            glDrawArrays(GL_TRIANGLE_FAN, 0, 6);
            break;

        case Figure::Pentagon:
            glUniform3f(colorUniformLoc, 0.0f, 0.0f, 1.0f); // blue
            glBindVertexArray(VAOs[2]);
            glDrawArrays(GL_TRIANGLE_FAN, 0, 7);
            break;
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

    // Cleanup 
    glDeleteProgram(program);
    glDeleteBuffers(3, VBOs);
    glDeleteVertexArrays(3, VAOs);

    return 0;
}