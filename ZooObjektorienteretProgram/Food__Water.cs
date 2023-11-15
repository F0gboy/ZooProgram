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
        private SoundEffect eatingSound;
        private SoundEffect drinkingSound;
        private int waterLevel = 100;
        private int foodLevel = 100;
        private int foodLevelNew;
        private int switchNum;
        private int waterLevelNew;
        private int switchNum1;

        public Food___Water()
        {
            
        }
        /// <summary>
        /// Her loader jeg alt der har med food and Water
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            eatingSound = content.Load<SoundEffect>("Eat Sound");
            drinkingSound = content.Load<SoundEffect>("Drinking sound");

            

            foodSprite1 = content.Load<Texture2D>("Food1");
            foodSprite2 = content.Load<Texture2D>("Food2");
            foodSprite3 = content.Load<Texture2D>("Food3");

            waterSprite1 = content.Load<Texture2D>("Water1");
            waterSprite2 = content.Load<Texture2D>("Water2");
            waterSprite3 = content.Load<Texture2D>("Water3");

            
        }
        /// <summary>
        /// En metode der update food og water level som bliver kladt i gameworld
        /// </summary>
        public void Update()
        {
            // Her tjekker den food level
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
            // Her tjekker den water level
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

        /// <summary>
        /// Her har jeg Draw til at draw både water og food 
        /// som bliver styret af switch case som for der værdi fra update metoden
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //det her jeg bestemmer hvad for et food sprite der skal visses
            switch (switchNum)
            {
                case 1: foodSprite = foodSprite3; break;

                case 2: foodSprite = foodSprite2; break;

                case 3: foodSprite = foodSprite1; break;


                default:
                    break;
            }           
            //spriteBatch.Draw(foodSprite, position1, Color.White);

            //det her jeg bestemmer hvad for et food sprite der skal visses
            switch (switchNum1)
            {
                case 1: waterSprite = waterSprite3; break;

                case 2: waterSprite = waterSprite2; break;

                case 3: waterSprite = waterSprite1; break;


                default:
                    break;
            }
            //spriteBatch.Draw(waterSprite, position2, Color.White);


           
        }
        /// <summary>
        /// En metode man klader for at fylde Waterlevel op
        /// og den kan ikke overstige en værdi på 100
        /// </summary>
        public void AddMoreWater()
        {
            waterLevel += 100;
            if (waterLevel > 100)
            {
                waterLevel = 100;
            }
        }
        /// <summary>
        /// En metode man klader for at fylde foodlevel op
        /// og den kan ikke overstige en værdi på 100
        /// </summary>
        public void AddMoreFood()
        {
            foodLevel += 100;
            if (foodLevel > 100)
            {
                foodLevel = 100;
            }
        }
        /// <summary>
        /// En metode der tømmer water og food level
        /// og den bliver kladt ude i gameworld update
        /// </summary>
        public void Drain()
        {
            
            
                waterLevel--;
                //drinkingSound.Play();

            
            
            
                foodLevel--;
                //eatingSound.Play();
                

            
        }
    }
}
