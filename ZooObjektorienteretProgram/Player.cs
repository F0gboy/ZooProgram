using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    //hej
    internal class Player
    {
        private Point mousePosition;
        private MouseState mouseState;
        private bool pressed;
        private ContentManager content;
        GraphicsDeviceManager graphicsDeviceManager;

        private Button testButton;

        public Player(ContentManager content, SpriteBatch spriteBatch)
        {
            this.content = content;

            //Test Button
            testButton = new Button(content);
            testButton.rect = new Rectangle(100,100,testButton.rect.Width, testButton.rect.Height);
        }

        public void MouseUpdate()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);


            //Test Button
            if (testButton.rect.Contains(mousePosition) == true && mouseState.LeftButton == ButtonState.Pressed && pressed == false)
            {


                pressed = true;
                
            }
            else if (mouseState.LeftButton == ButtonState.Released)
            {
                pressed = false;
            
            
                
            }
            
        }
        public void DrawButtons(SpriteBatch spriteBatch) 
        {
            testButton.Draw(spriteBatch);

        }

    }
}
