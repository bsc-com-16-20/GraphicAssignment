#version 330 core

// Input variables
in vec3 vertexColor;    // Vertex color from vertex shader
in vec2 texCoord;       // Texture coordinates from vertex shader

// Output color
out vec4 FragColor;

// Uniforms
uniform sampler2D texture1; // Texture sampler

void main()
{
    // If texture coordinates are available, use texture sampling
    // Otherwise, use the vertex color
    if (texCoord.x >= 0.0 && texCoord.y >= 0.0) {
        FragColor = texture(texture1, texCoord);
    } else {
        FragColor = vec4(vertexColor, 1.0);
    }
}
