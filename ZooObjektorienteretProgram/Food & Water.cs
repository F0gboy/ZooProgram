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

        public Food___Water(Rectangle rec)
        {
            this.rectangle = rec;
            this.rectangle1 = rec;
            
        }
        public override void LoadContent(ContentManager content)
        {
            eatingSound = content.Load<SoundEffect>("Eat Sound");
            drinkingSound = content.Load<SoundEffect>("Drinking sound");

            foodSprite1 = content.Load<Texture2D>("Food1");
            foodSprite2 = content.Load<Texture2D>("Food2");
            foodSprite3 = content.Load<Texture2D>("Food3");

            foodSprite = foodSprite3;

            waterSprite1 = content.Load<Texture2D>("Water1");
            waterSprite2 = content.Load<Texture2D>("Water2");
            waterSprite3 = content.Load<Texture2D>("Water3");

            waterSprite = waterSprite3;
        }

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
        }


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
        public void Drain()
        {
            
            
                waterLevel--;
                //drinkingSound.Play();

            
            
            
                foodLevel--;
                //eatingSound.Play();
                

            
        }

    }
}
