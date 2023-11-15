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
        public Rectangle center;


        public Animal(Rectangle Center)
        {
            this.center = Center;
        }


        public void SelectSprite(Texture2D spriteTag, Rectangle rec)
        {
            sprite = spriteTag;
            rectangle = new Rectangle(rec.X, rec.Y, sprite.Width * 3, sprite.Height * 3);
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
            int numberx = rnd.Next(-2, 3);
            int numbery = rnd.Next(-2, 3);

            if (rnd.Next(1, 10) > 6)
            {
                if (!rectangle.Intersects(center))
                {

                    if (center.X > rectangle.X)
                    {
                        rectangle.X += 1;
                    }
                    else { rectangle.X -= 1; }

                    if (center.Y > rectangle.Y)
                    {
                        rectangle.Y += 1;
                    }
                    else { rectangle.Y -= 1; }
                }
                else
                {
                    rectangle.X += numberx;
                    rectangle.Y += numbery;
                }
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