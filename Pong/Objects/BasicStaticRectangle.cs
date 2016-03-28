using Microsoft.Xna.Framework.Graphics;

namespace Pong.Objects
{
    public sealed class BasicStaticRectangle : BaseObject
    {
        public BasicStaticRectangle(string name, BasicEffect basicEffect, float initialX, float initialY, float initialWidth = 1f, float initialHeight = 1f) 
            : base(name,basicEffect,initialX,initialY,initialWidth,initialHeight)
        {
           
        }
    }
}