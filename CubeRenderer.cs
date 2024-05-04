using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace LearnOpenTK.Common
{
    // The main class where you create and render the cubes
    public class CubeRenderer
    {
        private Shader _shader;
        private Cube _redCube;
        private Cube _yellowCube;
        private Cube _texturedCube;

        public void Load()
        {
            // Load shaders
            _shader = new Shader("vertex_shader.vert", "fragment_shader.frag");

              // Define vertices and indices for cubes
            float[] vertices =
            {
                // Positions          // Colors           // Texture Coordinates
                -0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  0.0f, 0.0f,
                 0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  1.0f, 0.0f,
                 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  1.0f, 1.0f,
                 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  1.0f, 1.0f,
                -0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  0.0f, 1.0f,
                -0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f,  0.0f, 0.0f,

                -0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  0.0f, 0.0f,
                 0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  1.0f, 0.0f,
                 0.5f,  0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  1.0f, 1.0f,
                 0.5f,  0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  1.0f, 1.0f,
                -0.5f,  0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  0.0f, 1.0f,
                -0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 0.0f,  0.0f, 0.0f,

                -0.5f,  0.5f,  0.5f,  0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
                -0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  1.0f, 1.0f,
                -0.5f, -0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
                -0.5f, -0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
                -0.5f, -0.5f,  0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 0.0f,
                -0.5f,  0.5f,  0.5f,  0.0f, 0.0f, 1.0f,  1.0f, 0.0f,

                 0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 0.0f,  1.0f, 0.0f,
                 0.5f,  0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  1.0f, 1.0f,
                 0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,
                 0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,
                 0.5f, -0.5f,  0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
                 0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 0.0f,  1.0f, 0.0f,

                -0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  0.0f, 1.0f,
                 0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  1.0f, 1.0f,
                 0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 1.0f,  1.0f, 0.0f,
                 0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 1.0f,  1.0f, 0.0f,
                -0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 1.0f,  0.0f, 0.0f,
                -0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  0.0f, 1.0f,

                -0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  0.0f, 1.0f,
                 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 1.0f,
                 0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 0.0f,
                 0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 0.0f,
                -0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 1.0f,  0.0f, 0.0f,
                -0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  0.0f, 1.0f
            };

            uint[] indices =
            {
                0, 1, 3, // first triangle
                1, 2, 3  // second triangle
            };


            // Create cubes
            _redCube = new Cube(vertices, indices, Vector3.One, Vector3.Zero, Vector3.UnitY, Color4.Red);
            _yellowCube = new Cube(vertices, indices, Vector3.One * 0.25f, Vector3.UnitX * 6.0f, Vector3.UnitY, Color4.Yellow);
            _texturedCube = new Cube(vertices, indices, Vector3.One * 0.5f, Vector3.UnitX * 3.0f, Vector3.UnitY, new Vector2(0.0f, 0.0f), "Textures/wall.jpg");
        }

        public void Render(float deltaTime)
        {
            // Use the shader
            _shader.Use();

            // Render red cube
            _redCube.Render();

            // Render yellow cube
            _yellowCube.Render();

            // Render textured cube
            _texturedCube.Render();
        }

        public void Unload()
        {
            // Dispose of resources
            _redCube.Dispose();
            _yellowCube.Dispose();
            _texturedCube.Dispose();
            GL.DeleteProgram(_shader.Handle);
        }
    }
}
