using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Objects;

namespace Pong
{
    public class GameLogic
    {
        private int _frameCount;

        public void Update(Dictionary<string, BaseObject> objects)
        {
            var ball = objects["Ball"] as GameBall;
            var playerLeftBat = objects["LeftBat"] as PlayerBat;
            var playerRightBat = objects["RightBat"] as PlayerBat;
            foreach (var baseObject in objects.Where(x => !ReferenceEquals(x.Value, ball)))
            {
                if (ball.BoundingBox.Intersects(baseObject.Value.BoundingBox))
                {
                    switch (baseObject.Key)
                    {
                        case "Top":
                        case "Bot":
                            ball.Bounce();
                            break;
                        case "LeftBat":
                            BallCollideLeftBat(playerLeftBat, ball);
                            break;
                        case "RightBat":
                            BallCollideRightBat(playerRightBat, ball);
                            break;
                        case "Left":
                        case "Right":
                            ball.ResetPosition();
                            break;
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerLeftBat.SetVelocity(new Vector3(-0.60f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerLeftBat.SetVelocity(new Vector3(0.60f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }
            else
            {
                playerLeftBat.SetVelocity(new Vector3(0f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                playerRightBat.SetVelocity(new Vector3(-0.60f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                playerRightBat.SetVelocity(new Vector3(0.60f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }
            else
            {
                playerRightBat.SetVelocity(new Vector3(0f, playerLeftBat.Velocity.Y, playerLeftBat.Velocity.Z));
            }


            _frameCount++;
        }

        private void BallCollideLeftBat(PlayerBat playerBat, GameBall ball)
        {
            if (ball.Velocity.Y < 0f)
            {
                var distance = ball.Position.X - playerBat.Position.X;

                var positive = distance > 0f;
                var normalizedDistance = Math.Abs(distance) / 10f;

                ball.HitBat(normalizedDistance, positive);
            }
        }

        private void BallCollideRightBat(PlayerBat playerBat, GameBall ball)
        {
            if (ball.Velocity.Y > 0f)
            {
                var distance = ball.Position.Y - playerBat.Position.Y;

                var positive = distance > 0f;
                var normalizedDistance = Math.Abs(distance) / 6f;

                ball.HitBat(normalizedDistance, positive);
            }
        }
    }
}