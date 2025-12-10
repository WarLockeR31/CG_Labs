#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec3 aNormal;

out vec3 FragPos;
out vec3 Normal;
out vec2 TexCoords;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    // Позиция фрагмента в мире (нужна для расчета освещения)
    FragPos = vec3(model * vec4(aPos, 1.0));

    // Нормаль тоже нужно повернуть, если объект вращается
    // (Для простоты используем mat3(model), для идеальной точности нужен Normal Matrix)
    Normal = mat3(model) * aNormal;

    TexCoords = aTexCoord;

    gl_Position = projection * view * vec4(FragPos, 1.0);
}