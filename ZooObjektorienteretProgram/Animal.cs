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
        private Money cash;
        private float adjustedPrice;


        public Animal(Rectangle Center, Money cash)
        {
            this.center = Center;
            this.cash = cash;
        }


        public void SelectSprite(Texture2D spriteTag, Rectangle rec)
        {
            //select sprite and set rectangle
            sprite = spriteTag;
            rectangle = new Rectangle(rec.X, rec.Y, sprite.Width * 3, sprite.Height * 3);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //if sprite is not null, draw it
            if (sprite != null)
            {
                 spriteBatch.Draw(sprite, rectangle, Color.White);
            }
        }

        public void Move()
        {
            int numberx = rnd.Next(-2, 3);
            int numbery = rnd.Next(-2, 3);

            if (rnd.Next(1, 10) > 6)
            {
                //if animal is outside of center, move it towards center
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
                    //if animal is inside center, move it randomly
                    rectangle.X += numberx;
                    rectangle.Y += numbery;
                }


            }

            

        }

        public void ClickedAnimal()
        {
            //if animal is clicked, add money and set dead to true
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);
            if (rectangle.Contains(mousePosition) == true)
            {
                adjustedPrice = (rectangle.Width - 50) + (price*0.6f);
                cash.AddMoney(adjustedPrice);
                dead = true;
            }
        }
        public override void LoadContent(ContentManager content)
        {
            
        }

        public void Grow()
        {
            //if random number is above 2 and rectangle is smaller than 76, grow animal
            if (rnd.Next(-1,4) > 2 && rectangle.Width < 76)
            {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + 1, rectangle.Height + 1);
            
            }
               
        }
    }
}