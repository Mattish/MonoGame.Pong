using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Objects
{
    public class GameBall : BasicMovingRectangle
    {
        public GameBall(string name, BasicEffect basicEffect, float initialX, float initialY) : base(name, basicEffect, initialX, initialY, 4, 4)
        {
        }

        public void Bounce()
        {
            Velocity = new Vector3(-Velocity.X, Velocity.Y, Velocity.Z);
        }

        internal void HitBat(float normalizedDistance, bool positive)
        {
            if (normalizedDistance < 0.15f)
            {
                Velocity = new Vector3(
                    (Velocity.X * 1.05f),
                    -(Velocity.Y * 1.05f),
                    Velocity.Z);
                return;
            }

            if (normalizedDistance > 0.75f)
            {
                var total = Math.Abs(Velocity.X) + Math.Abs(Velocity.Y);
                total *= 1.05f;
                var totalHalf = total / 2f;
                if (positive)
                {
                    Velocity = new Vector3(
                        Velocity.X > 0f ? -totalHalf : totalHalf,
                        Velocity.X > 0f ? -totalHalf : totalHalf,
                        Velocity.Z);
                }
                return;
            }


            Velocity = new Vector3(
                    (Velocity.X * 1.05f) * (1f + normalizedDistance / 10f),
                    -(Velocity.Y * 1.05f) * (1f - normalizedDistance / 10f),
                    Velocity.Z);

        }

        public void ResetPosition()
        {
            Position = Vector3.Zero;
        }
    }

    public class PlayerBat : BasicMovingRectangle
    {
        public PlayerBat(string name, BasicEffect basicEffect, float initialX, float initialY) : base(name, basicEffect, initialX, initialY, 4, 16)
        {
        }
    }
}