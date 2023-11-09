using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    public class AnimalSpawner : Game
    {
        private Texture2D sheep;
        private Texture2D pig;
        private Texture2D cow;
        private Texture2D chicken;
        private Texture2D horse;
        private Texture2D bunny;
        private Texture2D dolphin;
        private Texture2D unicorn;
        private Texture2D fish;
        private Texture2D duck;

        private int AnimalValue = 0;
        private int MaxAnimalValue = 10;

        public void UpdateAnimalValue(int newValue)
        {
            if (newValue >= 0 && newValue <= MaxAnimalValue)
            {
                AnimalValue = newValue;
            }
            else if (newValue > MaxAnimalValue)
            {
                AnimalValue = MaxAnimalValue;
            }
            
        }


        public void SpawnAnimal()
        {
            // Case to choice animals. 
            switch (AnimalValue)
            {
                case 1:
                    Console.WriteLine("sheep");
                    Content.Load<Texture2D>("tile_sheep");
                    break;
                case 2:
                    Console.WriteLine("pig");
                    pig = Content.Load<Texture2D>("tile_pig");
                    break;
                case 3:
                    Console.WriteLine("cow");
                    cow = Content.Load<Texture2D>("tile_cow");
                    break;
                case 4:
                    Console.WriteLine("chicken");
                    chicken = Content.Load<Texture2D>("tile_chicken");
                    break;
                case 5:
                    Console.WriteLine("horse");
                    horse = Content.Load<Texture2D>("tile_horse");
                    break;
                case 6:
                    Console.WriteLine("bunny");
                    bunny = Content.Load<Texture2D>("tile_bunny");
                    break;
                case 7:
                    Console.WriteLine("dolphin");
                    dolphin = Content.Load<Texture2D>("tile_dolphin");
                    break;
                case 8:
                    Console.WriteLine("unicorn");
                    unicorn = Content.Load<Texture2D>("tile_unicorn");
                    break;
                case 9:
                    Console.WriteLine("fish");
                    fish = Content.Load<Texture2D>("tile_fish");
                    break;
                case 10:
                    Console.WriteLine("Duck");
                    duck = Content.Load<Texture2D>("tile_duck");
                    break;
                default:
                    Console.WriteLine("could not find an animal");
                    break;

            }
         }
    }
}
