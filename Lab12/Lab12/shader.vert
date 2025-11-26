#version 330 core

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec3 aColor;
layout(location = 2) in vec2 aTexCoord;

out vec3 vColor;
out vec2 vTexCoord;

uniform vec3 uOffset;
uniform mat3 uWorldRot;

void main()
{
    vec3 worldPos = uWorldRot * aPos + uOffset;

    vColor    = aColor;
    vTexCoord = aTexCoord;

    gl_Position = vec4(worldPos, 1.0);
}
