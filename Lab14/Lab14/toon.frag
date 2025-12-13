#version 330 core
out vec4 FragColor;

struct Material {
    sampler2D diffuse;
    float shininess;
};

struct DirLight {
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct PointLight {
    vec3 position;
    float constant;
    float linear;
    float quadratic;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct SpotLight {
    vec3 position;
    vec3 direction;
    float cutOff;
    float outerCutOff;
    float constant;
    float linear;
    float quadratic;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform DirLight dirLight;
uniform PointLight pointLight;
uniform SpotLight spotLight;
uniform Material material;

// Функции для расчета освещения с тоун-шейдингом
vec3 CalcDirLightToon(DirLight light, vec3 normal, vec3 viewDir);
vec3 CalcPointLightToon(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir);
vec3 CalcSpotLightToon(SpotLight light, vec3 normal, vec3 fragPos, vec3 viewDir);

// Количество уровней для тоун-шейдинга
const int levels = 4;

void main()
{
    vec3 norm = normalize(Normal);
    vec3 viewDir = normalize(viewPos - FragPos);
    
    // Накапливаем освещение от всех источников
    vec3 result = vec3(0.0);
    
    // Солнце (Направленный)
    result += CalcDirLightToon(dirLight, norm, viewDir);
    
    // Лампа (Точечный)
    result += CalcPointLightToon(pointLight, norm, FragPos, viewDir);
    
    // Фонарик (Прожектор)
    result += CalcSpotLightToon(spotLight, norm, FragPos, viewDir);
    
    // Добавляем черный контур на гранях
    float edge = max(0.0, dot(norm, viewDir));
    if (edge < 0.3) {
        result = vec3(0.0, 0.0, 0.0); // Черный контур
    }
    
    FragColor = vec4(result, 1.0);
}

// Квантование значения для тоун-эффекта
float quantize(float value, int levels) {
    return floor(value * levels) / levels;
}

vec3 CalcDirLightToon(DirLight light, vec3 normal, vec3 viewDir) {
    vec3 lightDir = normalize(-light.direction);
    
    // Диффузное освещение с квантованием
    float diff = max(dot(normal, lightDir), 0.0);
    diff = quantize(diff, levels);
    
    // Спекулярное освещение с квантованием
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    spec = quantize(spec, levels);
    
    // Получаем цвет текстуры
    vec3 texColor = vec3(texture(material.diffuse, TexCoords));
    
    // Комбинируем с квантованным освещением
    vec3 ambient = light.ambient * texColor;
    vec3 diffuse = light.diffuse * diff * texColor;
    vec3 specular = light.specular * spec;
    
    return ambient + diffuse + specular;
}

vec3 CalcPointLightToon(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir) {
    vec3 lightDir = normalize(light.position - fragPos);
    
    // Диффузное освещение с квантованием
    float diff = max(dot(normal, lightDir), 0.0);
    diff = quantize(diff, levels);
    
    // Спекулярное освещение с квантованием
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    spec = quantize(spec, levels);
    
    // Затухание
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));
    
    vec3 texColor = vec3(texture(material.diffuse, TexCoords));
    
    vec3 ambient = light.ambient * texColor;
    vec3 diffuse = light.diffuse * diff * texColor;
    vec3 specular = light.specular * spec;
    
    return (ambient + diffuse + specular) * attenuation;
}

vec3 CalcSpotLightToon(SpotLight light, vec3 normal, vec3 fragPos, vec3 viewDir) {
    vec3 lightDir = normalize(light.position - fragPos);
    
    // Диффузное освещение с квантованием
    float diff = max(dot(normal, lightDir), 0.0);
    diff = quantize(diff, levels);
    
    // Спекулярное освещение с квантованием
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    spec = quantize(spec, levels);
    
    // Затухание
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));
    
    // Интенсивность прожектора
    float theta = dot(lightDir, normalize(-light.direction));
    float epsilon = light.cutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    
    vec3 texColor = vec3(texture(material.diffuse, TexCoords));
    
    vec3 ambient = light.ambient * texColor;
    vec3 diffuse = light.diffuse * diff * texColor;
    vec3 specular = light.specular * spec;
    
    return (ambient + diffuse + specular) * attenuation * intensity;
}