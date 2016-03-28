using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public sealed class BasicStaticSquare : BasicStaticObject
    {
        public BasicStaticSquare(string name, BasicEffect basicEffect, float initialX, float initialY, float size = 2f) : base(name)
        {
            Vertex = new VertexPositionTexture[6];
            var halfSize = size / 2f;
            Vertex[0].Position = new Vector3(-halfSize, -halfSize, 0);
            Vertex[1].Position = new Vector3(-halfSize, halfSize, 0);
            Vertex[2].Position = new Vector3(halfSize, -halfSize, 0);
            Vertex[3].Position = Vertex[1].Position;
            Vertex[4].Position = new Vector3(halfSize, halfSize, 0);
            Vertex[5].Position = Vertex[2].Position;

            BasicEffect = basicEffect;
            BasicEffect.DiffuseColor = new Vector3(1f, 0f, 0f);
            Position = new Vector3(initialX, initialY, 0);
            BasicEffect.World = Matrix.Identity * Matrix.CreateTranslation(Position);
            AmountOfTriangles = Vertex.Length / 3;
            BoundingBox = BoundingBox.CreateFromPoints(new[]
            {
                Vertex[0].Position + Position,
                Vertex[1].Position + Position,
                Vertex[2].Position + Position,
                Vertex[4].Position + Position,
            });
        }
    }
}