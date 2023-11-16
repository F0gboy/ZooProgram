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


        public Animal(Rectangle Center, Money cash)
        {
            this.center = Center;
            this.cash = cash;
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
                 spriteBatch.Draw(sprite, rectangle, Color.White);
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
        }

        public void ClickedAnimal()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);
            if (rectangle.Contains(mousePosition) == true)
            {
                cash.AddMoney(cash.baseMoney*price*2);
                dead = true;
            }
        }
        public override void LoadContent(ContentManager content)
        {
            
        }
    }
}