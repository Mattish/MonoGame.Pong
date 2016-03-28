using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Objects
{
    public class BasicMovingRectangle : BaseObject
    {
        public Vector3 Velocity { get; protected set; }
        public Vector3 TopLeft { get; protected set; }
        public Vector3 TopRight { get; protected set; }
        public Vector3 BottomLeft { get; protected set; }
        public Vector3 BottomRight { get; protected set; }

        public BasicMovingRectangle(string name, BasicEffect basicEffect, float initialX, float initialY, float initialWidth = 1f, float initialHeight = 1f)
            : base(name, basicEffect, initialX, initialY, initialWidth, initialHeight)
        {

        }

        public void SetVelocity(Vector3 velocity)
        {
            Velocity = velocity;
        }

        public override void Update()
        {
            Position += Velocity;
            TopLeft = Vertex[0].Position + Position;
            TopRight = Vertex[1].Position + Position;
            BottomLeft = Vertex[2].Position + Position;
            BottomRight = Vertex[4].Position + Position;
            BoundingBox = BoundingBox.CreateFromPoints(new[]
            {
                TopLeft,
                TopRight,
                BottomLeft,
                BottomRight
            });
        }
    }
}