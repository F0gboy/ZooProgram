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
        public void SpawnAnimal()
        {


            // placeholder to get acces to the case. 
            Console.WriteLine("Choice an animal");
            string animal = Console.ReadLine();
            
            // Case to choice animals. 
            switch (animal)
            {
                case "sheep":
                    sheep = Content.Load<Texture2D>("tile_sheep");

                    break;
                case "Pig":
                    Console.WriteLine("pig");
                    break;
                case "Cow":
                    Console.WriteLine("cow");
                    break;
                case "Chicken":
                    Console.WriteLine("chicken");
                    break;
                case "Horse":
                    Console.WriteLine("horse");
                    break;
                case "Bunny":
                    Console.WriteLine("bunny");
                    break;
                case "Bee":
                    Console.WriteLine("bee");
                    break;
                case "Unicorn":
                    Console.WriteLine("unicorn");
                    break;
                case "Fish":
                    Console.WriteLine("fish");
                    break;
                case "Duck":
                    Console.WriteLine("Duck");
                    break;
                default:
                    Console.WriteLine("could not find an animal");
                    break;

            }
         }
    }
}
