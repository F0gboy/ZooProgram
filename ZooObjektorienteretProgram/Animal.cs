using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    internal class Animal : GameObject
    {
        private Point mousePosition;
        private MouseState mouseState;
        private static Random rnd = new Random();
        protected Texture2D sprite;
        public Vector2 position;
        public float price;
        public Rectangle rectangle;
        public bool dead = false;


        public Animal()
        {
            
        }


        public void SelectSprite(Texture2D spriteTag)
        {
            sprite = spriteTag;
            rectangle = new Rectangle(250 + (rnd.Next(0, 150)), 100 + (rnd.Next(0, 150)), sprite.Width * 3, sprite.Height * 3);
            
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null)
            {
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            spriteBatch.Draw(sprite, rectangle, Color.White);
            spriteBatch.End();

            }
        }

        public void Move()
        {
            if (rnd.Next(1, 10) > 3)
            {

            }
            else
            {
                rectangle.X += rnd.Next(-2, 3);
                rectangle.Y += rnd.Next(-2, 3);
            }

            //int w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //int h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //if (rectangle.X > 480)
            //{
            //    rectangle.X = 479;
            //}
            //if (rectangle.X < 0)
            //{
            //    rectangle.X = 0;
            //}

            //if (rectangle.Y > h)
            //{
            //    rectangle.Y = h;
            //}
            //if (rectangle.Y < 0)
            //{
            //    rectangle.Y = 0;
            //}



            


            //Animal pressed
            
            
        }

        public void ClickedAnimal()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);
            if (rectangle.Contains(mousePosition) == true)
            {
                dead = true;
            }
        }
        public override void LoadContent(ContentManager content)
        {
            
        }
    }
}