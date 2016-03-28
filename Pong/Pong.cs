using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Pong : BasePong
    {
        private readonly List<BasicStaticObject> _basicStaticObjects = new List<BasicStaticObject>();
        private readonly List<BasicMovingRectangle> _basicMovingRectangles = new List<BasicMovingRectangle>();

        private GameBall _gameBall;

        public Pong(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager) : base(graphicsDevice, graphicsDeviceManager) { }

        public void Setup()
        {
            var basicEffect = new BasicEffect(GraphicsDevice);
            _gameBall = new GameBall("Ball", basicEffect, 4, 4);
            _gameBall.SetVelocity(new Vector3(0.475f, 0.575f, 0f));
            _basicMovingRectangles.Add(_gameBall);



            var height = 40f;
            var width = 66.5f;

            //Top side
            _basicStaticObjects.Add(new BasicStaticRectangle("Top", basicEffect, -height, 0, (width + 1) * 2, 2));
            //Bottom side
            _basicStaticObjects.Add(new BasicStaticRectangle("Bot", basicEffect, height, 0, (width + 1) * 2, 2));
            //Right side
            _basicStaticObjects.Add(new BasicStaticRectangle("Right", basicEffect, 0, width, 2, height * 2));
            //Left side
            _basicStaticObjects.Add(new BasicStaticRectangle("Left", basicEffect, 0, -width, 2, height * 2));

            var top = _basicStaticObjects[0];
            var bottom = _basicStaticObjects[1];
            var right = _basicStaticObjects[2];
            var left = _basicStaticObjects[3];

            if (!top.BoundingBox.Intersects(right.BoundingBox) || !top.BoundingBox.Intersects(left.BoundingBox)
                || !bottom.BoundingBox.Intersects(right.BoundingBox) || !bottom.BoundingBox.Intersects(left.BoundingBox))
            {
                throw new Exception("Setup failed when creating walls");
            }
        }

        public void Update()
        {
            foreach (var basicMovingRectangle in _basicMovingRectangles.Where(x => x != null))
            {
                basicMovingRectangle.Update();
            }

            foreach (var basicMovingRectangle in _basicMovingRectangles.Where(x => x != null))
            {
                foreach (var basicStaticObject in _basicStaticObjects)
                {
                    if (basicStaticObject.BoundingBox.Intersects(basicMovingRectangle.BoundingBox))
                    {
                        basicMovingRectangle.CollideWith(basicStaticObject);
                    }
                }
            }
        }

        void DrawSquares()
        {
            var viewMatrix = GetViewMatrix();
            var projectionMatrix = GetProjectionMatrix();

            foreach (var basicStaticObject in _basicStaticObjects.Where(x => x != null))
            {
                basicStaticObject.Draw(GraphicsDevice, viewMatrix, projectionMatrix);
            }
            foreach (var basicMovingRectangle in _basicMovingRectangles.Where(x => x != null))
            {
                basicMovingRectangle.Draw(GraphicsDevice, viewMatrix, projectionMatrix);
            }
        }

        public void Draw(object gameTime)
        {
            DrawSquares();
        }
    }
}