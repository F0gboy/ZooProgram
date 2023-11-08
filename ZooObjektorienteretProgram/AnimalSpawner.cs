using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class AnimalSpawner
    {
        public void SpawnAnimal()
        {
            // placeholder to get acces to the case. 
            Console.WriteLine("Choice an animal");
            string animal = Console.ReadLine();
            // placeholder to get acces to the case. 


            // Case to choice animals. 
            switch (animal)
            {
                case "1":
                    // needs to be change into spawning an animal. 
                    Console.WriteLine("sheep");
                    Sheep sheep = new Sheep();
                    
                    // needs something to add position here. 

                    break;
                case "2":
                    Console.WriteLine("Duck");
                    break;
                // add more animals above here. 
                // need the default or something will go wrong. 
                default:
                    Console.WriteLine("could not find an animal");
                    break;

            }
         }
    }
}
