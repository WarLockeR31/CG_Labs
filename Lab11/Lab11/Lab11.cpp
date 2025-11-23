#include <fstream>
#include <GL/glew.h> 
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <sstream>
#include <vector>

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
    std::string vertexCode   = LoadFile("shader.vert");
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

    // 6. VBO + VAO 
    float vertices[] = {
        //  position   //   color
        -1.0f, -1.0f,   0.f, 1.f, 0.f,
         1.0f, -1.0f,   0.f, 1.f, 0.f,
         0.0f,  1.0f,   0.f, 1.f, 0.f
    };

    GLuint VBO = 0;
    glGenBuffers(1, &VBO);

    GLuint VAO = 0;
    glGenVertexArrays(1, &VAO);

    glBindVertexArray(VAO);

    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

    // Attributes
    GLint posLoc   = glGetAttribLocation(program, "aPos");
    GLint colorLoc = glGetAttribLocation(program, "aColor");
     
    if (posLoc == -1 || colorLoc == -1)
    {
        std::cerr << "Attribute not found in shader\n";
    }
     
    glBindVertexArray(VAO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
     
    // layout(location = 0) vec2 aPos;
    glVertexAttribPointer(posLoc, 2, GL_FLOAT, GL_FALSE,
                          5 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(posLoc);
     
    // layout(location = 1) vec3 aColor;
    glVertexAttribPointer(colorLoc, 3, GL_FLOAT, GL_FALSE,
                          5 * sizeof(float), (void*)(2 * sizeof(float)));
    glEnableVertexAttribArray(colorLoc);

    // Main cycle
    while (window.isOpen())
    {
        while (const std::optional event = window.pollEvent())
        {
            if (event->is<sf::Event::Closed>())
                window.close();
        }

        glClear(GL_COLOR_BUFFER_BIT);

        glUseProgram(program);
        glBindVertexArray(VAO);

        glDrawArrays(GL_TRIANGLES, 0, 3);

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
    glDeleteBuffers(1, &VBO);
    glDeleteVertexArrays(1, &VAO);

    return 0;
}
