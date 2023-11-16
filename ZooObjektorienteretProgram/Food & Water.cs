using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;

namespace ZooObjektorienteretProgram
{
    internal class Food___Water : GameObject
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D sprite;
        private Texture2D foodSprite;
        private Texture2D foodSprite1;
        private Texture2D foodSprite2;
        private Texture2D foodSprite3;
        private Texture2D waterSprite;
        private Texture2D waterSprite1;
        private Texture2D waterSprite2;
        private Texture2D waterSprite3;
        private List<Texture2D> waterSprites = new List<Texture2D>(3);
        private List<Texture2D> foodSprites = new List<Texture2D>(3);
        public Rectangle rectangle;
        public Rectangle rectangle1;
        private SoundEffect eatingSound;
        private SoundEffect drinkingSound;
        private int waterLevel = 100;
        private int foodLevel = 100;
        private int foodLevelNew;
        private int switchNum;
        private int waterLevelNew;
        private int switchNum1;
        private MouseState mouseState;
        private Point mousePosition;
        private bool pressed;
        private Random rnd = new Random();
        private Money money;
        public bool animalsPresent = false;

        public Food___Water(Rectangle rec, Money money)
        {
            this.rectangle = rec;
            this.rectangle1 = rec;
            this.money = money;
            
        }

        //load sprites
        public override void LoadContent(ContentManager content)
        {
            foodSprite1 = content.Load<Texture2D>("Food1");
            foodSprite2 = content.Load<Texture2D>("Food2");
            foodSprite3 = content.Load<Texture2D>("Food3");

            foodSprite = foodSprite3;

            waterSprite1 = content.Load<Texture2D>("Water1");
            waterSprite2 = content.Load<Texture2D>("Water2");
            waterSprite3 = content.Load<Texture2D>("Water3");

            waterSprite = waterSprite3;
        }

        //update food and water levels, and their sprites based on the levels
        public void Update()
        {
            foodLevelNew = foodLevel;
            if (foodLevelNew > 50)
            {
                switchNum = 1;
            }
            if (foodLevelNew < 50)
            {
                switchNum = 2;
            }
            if (foodLevelNew <= 0)
            {
                switchNum = 3;
            }

            waterLevelNew = waterLevel;
            if (waterLevelNew > 50)
            {
                switchNum1 = 1;
            }
            if (waterLevelNew < 50)
            {
                switchNum1 = 2;
            }
            if (waterLevelNew <= 0)
            {
                switchNum1 = 3;
            }

            
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);

            //if the player clicks on the food, the level increases and money decreases
            if (rectangle.Contains(mousePosition) == true && mouseState.LeftButton == ButtonState.Pressed && pressed == false)
            {
                AddMoreFood();
                money.SpendMoney(5);
                pressed = true;

            }
            else if (mouseState.LeftButton == ButtonState.Released)
            {
                pressed = false;
            }

            //if the player clicks on the water, the level increases and money decreases
            if (rectangle1.Contains(mousePosition) == true  && mouseState.LeftButton == ButtonState.Pressed && pressed == false)
                {
                    AddMoreWater();
                    money.SpendMoney(5);
                    pressed = true;

                }
                else if (mouseState.LeftButton == ButtonState.Released)
                 {
                pressed = false;
                 }
            




        }

        //draw the food and water sprites based on the switchNum and switchNum1
        public override void Draw( SpriteBatch spriteBatch)
        {

            switch (switchNum)
            {
                case 1: foodSprite = foodSprite3; break;

                case 2: foodSprite = foodSprite2; break;

                case 3: foodSprite = foodSprite1; break;


                default:
                    break;
            }           

            spriteBatch.Draw(foodSprite, rectangle, Color.White);

            switch (switchNum1)
            {
                case 1: waterSprite = waterSprite3; break;

                case 2: waterSprite = waterSprite2; break;

                case 3: waterSprite = waterSprite1; break;


                default:
                    break;
            }

            
            spriteBatch.Draw(waterSprite, rectangle1, Color.White);

        }

        //add more water and food
        public void AddMoreWater()
        {
            waterLevel += 100;
            if (waterLevel > 100)
            {
                waterLevel = 100;
            }
        }

        public void AddMoreFood()
        {
            foodLevel += 100;
            if (foodLevel > 100)
            {
                foodLevel = 100;
            }
        }

        //drain water and food
        public void Drain(List<Animal> animals)
        {
            waterLevel -= rnd.Next(0, 3);

            foodLevel -= rnd.Next(0, 3);
           
        }

    }
}
