using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
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
        protected Texture2D sprite;
        private ContentManager content;
        public bool pressed;
        


        public Button(ContentManager content)
        {
            
            LoadContent(content);

        }

        //draw button
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, rect, Color.White);

        }

        public override void LoadContent(ContentManager content)
        {

            

        }

      
    }
}
