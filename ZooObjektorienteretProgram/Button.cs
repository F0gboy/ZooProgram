using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
        private ContentManager content;


        public Button(ContentManager content)
        {
            
            LoadContent(content);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            spriteBatch.Draw(sprite, rect, Color.White);
            spriteBatch.End();

        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("Fence1");
            rect = new Rectangle(rect.X,rect.Y,sprite.Width,sprite.Height);

        }
    }
}
