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
    internal class SpawnButton : Button 
    {
        private int animalNum;
        private AnimalSpawner animalSpawner;
        public SpawnButton(ContentManager content, int animalNum, AnimalSpawner animalSpawner) : base(content)
        {
            this.animalNum = animalNum;
            this.animalSpawner = animalSpawner;
        }

        public void Spawn(Vector2 position)
        {
            animalSpawner.SpawnAnimal(animalNum);
            animalSpawner.animals[animalSpawner.animals.Count - 1].rectangle.X = (int)position.X;
            animalSpawner.animals[animalSpawner.animals.Count - 1].rectangle.Y = (int)position.Y;

        }

        public void SetSprite(Texture2D sprite)
        {
            base.sprite = sprite;
            rect = new Rectangle(rect.X, rect.Y, sprite.Width, sprite.Height);
        }


    }
}
