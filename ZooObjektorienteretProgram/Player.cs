using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    internal class Player
    {
        private Point mousePosition;
        private MouseState mouseState;
        private bool pressed;


        public Player()
        {

        }

        public void MouseUpdate()
        {
            Rectangle tempRect = new Rectangle();


            mousePosition = new Point(mouseState.X, mouseState.Y);
            mouseState = new MouseState();


            // Check if the mouse position is inside the rectangle
            if (tempRect.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && pressed == false)
            {
                pressed = true;
                
            }
            else if (mouseState.LeftButton == ButtonState.Released)
            {
                pressed = false;
            }
            {
                
            }
            
        }

    }
}
