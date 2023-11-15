using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class AnimalSpawner : Game
    {
        private Point mousePosition;
        private MouseState mouseState;

        private Texture2D sheep;
        private Texture2D pig;
        private Texture2D cow;
        private Texture2D chicken;
        private Texture2D horse;
        private Texture2D bunny;
        private Texture2D bull;
        private Texture2D fish;
        private Texture2D duck;
        private int selectedAnimal;
        private bool killTime = false;
        public List<Animal> animals = new List<Animal>();
        private Money cash;
        
        public AnimalSpawner(ContentManager content, Money cash)
        {
            this.cash = cash;
            LoadContent(content);
            

        } 

        public void AnimalUpdate()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (var animal in animals)
                {
                    animal.ClickedAnimal();
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {

                animals[i].Move();
                if (animals[i].dead == true)
                {
                    selectedAnimal = i;
                    killTime = true;
                    break;
                }
            }

            if (killTime == true)
            {
                animals.RemoveAt(selectedAnimal);
                killTime = false;
            }

        }

        public void SpawnAnimal(int spawnNum, List<Rectangle> centers)
        {
            // Case to choice animals. 
            switch (spawnNum)
            {
                case 0:
                    animals.Add(new Animal(centers[0], cash));
                    animals[animals.Count-1].SelectSprite(sheep, centers[0]);
                    animals[animals.Count - 1].price = 0.5f;
                    cash.SpendMoney(animals[animals.Count - 1].price*cash.baseMoney);
                    break;
                case 1:
                    animals.Add(new Animal(centers[1], cash));
                    animals[animals.Count-1].SelectSprite(pig, centers[1]);
                    animals[animals.Count - 1].price = 1f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;

                case 2:
                    animals.Add(new Animal(centers[2], cash));
                    animals[animals.Count-1].SelectSprite(cow, centers[2]);
                    animals[animals.Count - 1].price = 1.5f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 3:
                    animals.Add(new Animal(centers[3], cash));
                    animals[animals.Count-1].SelectSprite(chicken, centers[3]);
                    animals[animals.Count - 1].price = 2f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 4:
                    animals.Add(new Animal(centers[4], cash));
                    animals[animals.Count-1].SelectSprite(horse, centers[4]);
                    animals[animals.Count - 1].price = 2.5f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 5:
                    animals.Add(new Animal(centers[5], cash));
                    animals[animals.Count-1].SelectSprite(bunny, centers[5]);
                    animals[animals.Count - 1].price = 3f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 6:
                    animals.Add(new Animal(centers[6], cash));
                    animals[animals.Count-1].SelectSprite(bull, centers[6]);
                    animals[animals.Count - 1].price = 3.5f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 7:
                    animals.Add(new Animal(centers[7], cash));
                    animals[animals.Count-1].SelectSprite(fish, centers[7]);
                    animals[animals.Count - 1].price = 4f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                case 8:
                    animals.Add(new Animal(centers[8], cash));
                    animals[animals.Count-1].SelectSprite(duck, centers[8]);
                    animals[animals.Count - 1].price = 5f;
                    cash.SpendMoney(animals[animals.Count - 1].price * cash.baseMoney);
                    break;
                default:
                    Console.WriteLine("could not find an animal");
                    break;

            }
         }

        public void AnimalDraw(SpriteBatch spriteBatch)
        {
            if (animals.Count != 0)
            {
                foreach (var animal in animals)
                {
                    animal.Draw(spriteBatch);
                }
            }
        }
          
        public void LoadContent(ContentManager Content)
        {
            sheep = Content.Load<Texture2D>("tile_sheep");
            pig = Content.Load<Texture2D>("tile_pig");
            cow = Content.Load<Texture2D>("tile_cow");
            chicken = Content.Load<Texture2D>("tile_chicken");
            horse = Content.Load<Texture2D>("tile_horse");
            bunny = Content.Load<Texture2D>("tile_bunny");
            bull = Content.Load<Texture2D>("tile_bull");
            fish = Content.Load<Texture2D>("tile_fish");
            duck = Content.Load<Texture2D>("tile_duck");
        }


    }
}
