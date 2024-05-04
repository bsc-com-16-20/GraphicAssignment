using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;

namespace GraphicsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowSettings = new NativeWindowSettings
            {
                Size = new OpenTK.Mathematics.Vector2i(800, 600),
                Title = "Graphics Assignment"
            };

            using (var window = new GameWindow(GameWindowSettings.Default, windowSettings))
            {
                // Create and initialize the renderer
                var renderer = new CubeRenderer();
                renderer.Load();

                // Set up event handlers
                window.RenderFrame += (_, __) => Render(window, renderer);
                window.UpdateFrame += (_, __) => Update(window);

                // Run the application loop
                window.Run();
            }
        }

        static void Render(GameWindow window, CubeRenderer renderer)
        {
            // Clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Call the renderer to render the cubes
            renderer.Render(window.RenderTime);

            // Swap the buffers
            window.SwapBuffers();
        }

        
    }
}
