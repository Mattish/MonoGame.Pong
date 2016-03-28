using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Objects
{
    public abstract class BaseObject
    {
        public string Name { get; private set; }
        public BoundingBox BoundingBox { get; protected set; }
        public VertexPositionTexture[] Vertex { get; protected set; }
        public BasicEffect BasicEffect { get; protected set; }
        public Vector3 Position { get; protected set; }
        public int AmountOfTriangles { get; protected set; }

        protected BaseObject(string name, BasicEffect basicEffect, float initialX, float initialY, float initialWidth = 1f, float initialHeight = 1f)
        {
            Name = name;
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
                Vertex[4].Position + Position
            });
        }

        public void Draw(GraphicsDevice graphicsDevice, Matrix viewMatrix, Matrix projectionMatrix)
        {
            BasicEffect.View = viewMatrix;
            BasicEffect.Projection = projectionMatrix;
            BasicEffect.DiffuseColor = new Vector3(1f, 1f, 1f);
            BasicEffect.World = Matrix.Identity * Matrix.CreateTranslation(Position);
            foreach (var pass in BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Vertex, 0, AmountOfTriangles);
            }
        }

        public virtual void Update()
        {

        }
    }
}