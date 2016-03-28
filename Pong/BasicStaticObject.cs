using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public abstract class BasicStaticObject
    {
        public BoundingBox BoundingBox { get; protected set; }
        public VertexPositionTexture[] Vertex { get; protected set; }
        public BasicEffect BasicEffect { get; protected set; }
        public Vector3 Position { get; protected set; }
        public int AmountOfTriangles { get; protected set; }

        public void Draw(GraphicsDevice graphicsDevice, Matrix viewMatrix, Matrix projectionMatrix)
        {
            BasicEffect.View = viewMatrix;
            BasicEffect.Projection = projectionMatrix;

            foreach (var pass in BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Vertex, 0, AmountOfTriangles);
            }
        }
    }
}