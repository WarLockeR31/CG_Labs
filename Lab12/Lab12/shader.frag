#version 330 core

in vec3 vColor;
in vec2 vTexCoord;

out vec4 fragColor;

uniform float uColorMix;
uniform float uTextureMix;
uniform sampler2D uTexture;
uniform sampler2D uTexture2;
uniform int uUseTexture;
uniform int uRenderMode; // 1 -> circle

// helper: HSV -> RGB, hue in [0,1], s,v in [0,1]
vec3 hsv2rgb(float h, float s, float v)
{
    float C = v * s;
    float X = C * (1.0 - abs(mod(h * 6.0, 2.0) - 1.0));
    float m = v - C;
    vec3 rgb;
    if (h < 1.0/6.0) rgb = vec3(C, X, 0.0);
    else if (h < 2.0/6.0) rgb = vec3(X, C, 0.0);
    else if (h < 3.0/6.0) rgb = vec3(0.0, C, X);
    else if (h < 4.0/6.0) rgb = vec3(0.0, X, C);
    else if (h < 5.0/6.0) rgb = vec3(X, 0.0, C);
    else rgb = vec3(C, 0.0, X);
    return rgb + vec3(m);
}

void main()
{
    if (uRenderMode == 1)
    {
        // gradient circle: center white, hue around circumference
        // vTexCoord was set in vertex shader as scaled*0.5 + 0.5
        vec2 p = vTexCoord - vec2(0.5); // center at 0
        float r = length(p);

        // if outside radius ~0.5 -> discard (or make transparent background)
        if (r > 0.5)
        {
            discard;
        }

        // compute angle
        float angle = atan(p.y, p.x); // -pi..pi
        float hue = angle / (2.0 * 3.14159265358979323846) + 0.5; // 0..1

        float s = 1.0;
        float val = 1.0;
        vec3 rgb = hsv2rgb(hue, s, val);

        // center white blending: at center r=0 -> white; at edge r=0.5 -> full rgb
        float t = smoothstep(0.0, 0.5, r); // 0 at center, 1 at edge
        vec3 col = mix(vec3(1.0), rgb, t);

        fragColor = vec4(col, 1.0);
        return;
    }

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
