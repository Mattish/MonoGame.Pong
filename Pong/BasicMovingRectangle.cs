using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class GameBall : BasicMovingRectangle
    {
        public GameBall(string name, BasicEffect basicEffect, float initialX, float initialY) : base(name, basicEffect, initialX, initialY, 4, 4)
        {
        }

        public override void CollideWith(BaseObject baseObject)
        {
            switch (baseObject.Name)
            {
                case "Top":
                case "Bot":
                    SetVelocity(new Vector3(-Velocity.X, Velocity.Y, Velocity.Z));
                break;
            }
        }
    }

    public class BasicMovingRectangle : BaseObject
    {
        public BoundingBox BoundingBox { get; protected set; }
        public VertexPositionTexture[] Vertex { get; protected set; }
        public BasicEffect BasicEffect { get; protected set; }
        public Vector3 Position { get; protected set; }
        public Vector3 Velocity { get; protected set; }

        public int AmountOfTriangles { get; protected set; }

        public BasicMovingRectangle(string name, BasicEffect basicEffect, float initialX, float initialY, float initialWidth = 1f, float initialHeight = 1f) : base(name)
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

        public void SetVelocity(Vector3 velocity)
        {
            Velocity = velocity;
        }

        public void Update()
        {
            Position += Velocity;
            BoundingBox = BoundingBox.CreateFromPoints(new[]
            {
                Vertex[0].Position + Position,
                Vertex[1].Position + Position,
                Vertex[2].Position + Position,
                Vertex[4].Position + Position
            });

        }

        public virtual void CollideWith(BaseObject baseObject)
        {
            
        }
    }
}