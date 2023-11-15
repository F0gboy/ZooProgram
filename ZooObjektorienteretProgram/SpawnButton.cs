using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class SpawnButton : Button 
    {
        private int animalNum;
        private AnimalSpawner animalSpawner;
        private Money cash;
        private SpriteFont font;
        private Player player;
        private string text;
        public Color color = Color.White;
        public List<Rectangle> rects;

        public SpawnButton(ContentManager content, int animalNum, AnimalSpawner animalSpawner, Money cash, Player player, string text, List<Rectangle> Rects) : base(content)
        {
            this.player = player;
            this.animalNum = animalNum;
            this.animalSpawner = animalSpawner;
            this.cash = cash;
            this.text = text;
            this.rects = Rects;
        }
            
        public void Spawn(Vector2 position)
        {
            animalSpawner.SpawnAnimal(animalNum, rects);
            animalSpawner.animals[animalSpawner.animals.Count - 1].rectangle.X = (int)position.X;
            animalSpawner.animals[animalSpawner.animals.Count - 1].rectangle.Y = (int)position.Y;
            
        }

        public void SetSprite(Texture2D sprite)
        {
            base.sprite = sprite;
            rect = new Rectangle(rect.X, rect.Y, sprite.Width+100, sprite.Height);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sprite, rect, color);
            if (text != null && player.font != null)
            {
                spriteBatch.DrawString(player.font,text, new Vector2(rect.X+50,rect.Y), Color.Black);
            }
        }


    }
}
