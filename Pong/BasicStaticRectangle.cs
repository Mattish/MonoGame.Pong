using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public sealed class BasicStaticRectangle : BasicStaticObject
    {
        public BasicStaticRectangle(string name, BasicEffect basicEffect, float initialX, float initialY, float initialWidth = 1f, float initialHeight = 1f) : base(name)
        {
            Vertex = new VertexPositionTexture[6];
            var halfH = initialHeight / 2;
            var halfW = initialWidth / 2;
            Vertex[0].Position = new Vector3(-halfH, -halfW, 0);
            Vertex[1].Position = new Vector3(-halfH, halfW, 0);
            Vertex[2].Position = new Vector3(halfH, -halfW, 0);
            Vertex[3].Position = Vertex[1].Position;
            Vertex[4].Position = new Vector3(halfH, halfW, 0);
            Vertex[5].Position = Vertex[2].Position;

            BasicEffect = basicEffect;
            Position = new Vector3(initialX, initialY, 0);

            AmountOfTriangles = Vertex.Length / 3;
            BoundingBox = BoundingBox.CreateFromPoints(new[]
            {
                Vertex[0].Position + Position,
                Vertex[1].Position + Position,
                Vertex[2].Position + Position,
                Vertex[4].Position + Position,
            }
            );
        }
    }
}