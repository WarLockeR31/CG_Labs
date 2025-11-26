#version 330 core

in vec3 vColor;
in vec2 vTexCoord;

out vec4 FragColor;

// Текстура куба
uniform sampler2D uTexture;

// 0.0 — только текстура, 1.0 — только цвет вершин
uniform float uColorMix;

// 0 — игнорируем текстуру (тетраэдр), 1 — используем (куб)
uniform int uUseTexture;

void main()
{
    vec3 color = vColor;

    if (uUseTexture == 1)
    {
        vec3 tex = texture(uTexture, vTexCoord).rgb;
        // смешиваем текстуру и цвет вершин
        color = mix(tex, vColor, uColorMix);
    }

    FragColor = vec4(color, 1.0);
}
