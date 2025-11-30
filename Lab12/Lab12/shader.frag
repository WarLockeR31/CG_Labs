#version 330 core

in vec3 vColor;
in vec2 vTexCoord;

out vec4 fragColor;

uniform float uColorMix;
uniform float uTextureMix;
uniform sampler2D uTexture;
uniform sampler2D uTexture2;
uniform int uUseTexture;

void main()
{
    if (uUseTexture == 0) 
    {
        // Без текстуры - только цвет вершин
        fragColor = vec4(vColor, 1.0);
    }
    else if (uUseTexture == 1) 
    {
        // Одна текстура с смешиванием цвета
        vec4 texColor = texture(uTexture, vTexCoord);
        vec4 vertexColor = vec4(vColor, 1.0);
        fragColor = mix(texColor, vertexColor, uColorMix);
    }
    else if (uUseTexture == 2) 
    {
        // Две смешанные текстуры
        vec4 tex1Color = texture(uTexture, vTexCoord);
        vec4 tex2Color = texture(uTexture2, vTexCoord);
        fragColor = mix(tex1Color, tex2Color, uTextureMix);
    }
    else 
    {
        fragColor = vec4(vColor, 1.0);
    }
}