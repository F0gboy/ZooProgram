using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    internal class Button : GameObject
    {
        public Rectangle rect;
        private GraphicsDeviceManager graphics;
        private Texture2D sprite;
        private SpriteBatch spriteBatch;

        public Button()
        {

        }
        public override void Draw(GameTime GameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            spriteBatch.Draw(sprite, rect, Color.White);
            spriteBatch.End();

        }

        public override void LoadContent()
        {
            
            sprite = content.Load<Texture2D>("Button");

        }
    }
}
