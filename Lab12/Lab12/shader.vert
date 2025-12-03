#version 330 core

layout(location = 0) in vec3 aPos;     
layout(location = 1) in vec3 aColor;
layout(location = 2) in vec2 aTexCoord;

out vec3 vColor;
out vec2 vTexCoord;

uniform vec3 uOffset;
uniform mat3 uWorldRot;

uniform vec2 uCircleScale;
uniform int uRenderMode; // 0 - normal, 1 - circle

void main()
{
    if (uRenderMode == 1)
    {

        vec2 scaled = aPos.xy * uCircleScale;
        gl_Position = vec4(scaled.xy, 0.0, 1.0);

       
        vColor = aColor; 
        vTexCoord = scaled * 0.5 + vec2(0.5);
        return;
    }

    vec3 worldPos = uWorldRot * aPos + uOffset;

    vColor    = aColor;
    vTexCoord = aTexCoord;

    gl_Position = vec4(worldPos, 1.0);
}
