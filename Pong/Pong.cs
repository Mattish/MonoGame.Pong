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

        public Pong(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager) : base(graphicsDevice, graphicsDeviceManager) { }

        public void Setup()
        {
            _basicStaticObjects.Add(new BasicStaticSquare(new BasicEffect(GraphicsDevice), 4, 4, 4));

            var height = 40f;
            var width = 66.5f;

            //Top side
            _basicStaticObjects.Add(new BasicStaticRectangle(new BasicEffect(GraphicsDevice), -height, 0, (width + 1) * 2, 2));
            //Bottom side
            _basicStaticObjects.Add(new BasicStaticRectangle(new BasicEffect(GraphicsDevice), height, 0, (width + 1) * 2, 2));
            //Right side
            _basicStaticObjects.Add(new BasicStaticRectangle(new BasicEffect(GraphicsDevice), 0, width, 2, height * 2));
            //Left side
            _basicStaticObjects.Add(new BasicStaticRectangle(new BasicEffect(GraphicsDevice), 0, -width, 2, height * 2));

            var top = _basicStaticObjects[1];
            var bottom = _basicStaticObjects[2];
            var right = _basicStaticObjects[3];
            var left = _basicStaticObjects[4];

            if (!top.BoundingBox.Intersects(right.BoundingBox) || !top.BoundingBox.Intersects(left.BoundingBox)
                || !bottom.BoundingBox.Intersects(right.BoundingBox) || !bottom.BoundingBox.Intersects(left.BoundingBox))
            {
                throw new Exception("Setup failed when creating walls");
            }
        }

        public void Update()
        {

        }

        void DrawSquares()
        {
            var viewMatrix = GetViewMatrix();
            var projectionMatrix = GetProjectionMatrix();

            foreach (var basicStaticObject in _basicStaticObjects.Where(x => x != null))
            {
                basicStaticObject.Draw(GraphicsDevice, viewMatrix, projectionMatrix);
            }
        }

        public void Draw(object gameTime)
        {
            DrawSquares();
        }
    }
}