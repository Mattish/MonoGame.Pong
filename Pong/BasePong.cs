using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public abstract class BasePong
    {
        protected readonly GraphicsDevice GraphicsDevice;
        protected readonly GraphicsDeviceManager GraphicsDeviceManager;

        protected BasePong(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager)
        {
            GraphicsDevice = graphicsDevice;
            GraphicsDeviceManager = graphicsDeviceManager;
        }

        protected Matrix GetProjectionMatrix()
        {
            float aspectRatio = GraphicsDeviceManager.PreferredBackBufferWidth / (float)GraphicsDeviceManager.PreferredBackBufferHeight;
            float fieldOfView = MathHelper.PiOver4;
            float nearClipPlane = 1;
            float farClipPlane = 200;
            var projectionMatrix = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
            return projectionMatrix;
        }

        protected Matrix GetViewMatrix()
        {
            var cameraPosition = new Vector3(0.0000001f, 0, 100);
            var cameraLookAtVector = Vector3.Zero;
            var cameraUpVector = Vector3.UnitZ;
            var viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraLookAtVector, cameraUpVector);
            return viewMatrix;
        }
    }
}