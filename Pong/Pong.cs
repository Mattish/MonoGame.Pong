using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Objects;

namespace Pong
{
    public class Pong : BasePong
    {
        private BasicStaticRectangle _top;
        private BasicStaticRectangle _bottom;
        private BasicStaticRectangle _left;
        private BasicStaticRectangle _right;
        private Dictionary<string, BaseObject> _objects;
        private GameBall _gameBall;
        private PlayerBat _leftBat;
        private PlayerBat _rightBat;

        private GameLogic _gameLogic;

        public Pong(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager) : base(graphicsDevice, graphicsDeviceManager) { }

        public void Setup()
        {
            var height = 40f;
            var width = 66.5f;

            _objects = new Dictionary<string, BaseObject>();
            _gameLogic = new GameLogic();
            var basicEffect = new BasicEffect(GraphicsDevice);

            _gameBall = new GameBall("Ball", basicEffect, 4, 4);
            _gameBall.SetVelocity(new Vector3(0.775f, -0.710f, 0f));
            _objects.Add(_gameBall.Name, _gameBall);

            _leftBat = new PlayerBat("LeftBat", basicEffect, 0, -(width - width / 10f));
            _objects.Add(_leftBat.Name,_leftBat);
            _rightBat = new PlayerBat("RightBat", basicEffect, 0, width - width / 10f);
            _objects.Add(_rightBat.Name, _rightBat);

            _top = new BasicStaticRectangle("Top", basicEffect, -height, 0, (width + 1) * 2, 2);
            _objects.Add(_top.Name, _top);
            _bottom = new BasicStaticRectangle("Bot", basicEffect, height, 0, (width + 1) * 2, 2);
            _objects.Add(_bottom.Name, _bottom);
            _right = new BasicStaticRectangle("Right", basicEffect, 0, width, 2, height * 2);
            _objects.Add(_right.Name, _right);
            _left = new BasicStaticRectangle("Left", basicEffect, 0, -width, 2, height * 2);
            _objects.Add(_left.Name, _left);

            if (!_top.BoundingBox.Intersects(_right.BoundingBox) || !_top.BoundingBox.Intersects(_left.BoundingBox)
                || !_bottom.BoundingBox.Intersects(_right.BoundingBox) || !_bottom.BoundingBox.Intersects(_left.BoundingBox))
            {
                throw new Exception("Setup failed when creating walls");
            }
        }

        public void Update()
        {
            foreach (var basicMovingRectangle in _objects)
            {
                basicMovingRectangle.Value.Update();
            }

            _gameLogic.Update(_objects);

            
        }

        public void Draw(object gameTime)
        {
            var viewMatrix = GetViewMatrix();
            var projectionMatrix = GetProjectionMatrix();

            foreach (var keyValuePair in _objects)
            {
                keyValuePair.Value.Draw(GraphicsDevice, viewMatrix, projectionMatrix);
            }
        }
    }
}