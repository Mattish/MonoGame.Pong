using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager graphicsDeviceManager;

        public static int FrameCount;

        private Pong _pong;

        public Game()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _pong = new Pong(GraphicsDevice, graphicsDeviceManager);
            _pong.Setup();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _pong.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _pong.Draw(gameTime);

            FrameCount++;
            base.Draw(gameTime);
        }
    }
}
