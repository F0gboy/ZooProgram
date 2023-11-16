using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using static System.Formats.Asn1.AsnWriter;

namespace ZooObjektorienteretProgram
{
    internal class AnimalBoundaries
    {

        private SpriteBatch _spriteBatch;
        private Rectangle rectangle;
        private List<Texture2D> boundarySprites = new List<Texture2D>();
        private Vector2 spritePosition;
        private int chosenSprite;
        private float moveAmountX;
        private float moveAmountY;
        private string name;

        public AnimalBoundaries(int ChosenSprite, string Name, float MoveAmountX, float MoveAmountY) 
        { 
            // Set the variables
            this.chosenSprite = ChosenSprite;
            this.moveAmountX = MoveAmountX;
            this.moveAmountY = MoveAmountY;
            this.name = Name;
        }

        public void LoadContent(ContentManager content)
        {
            // Load all the sprites for the boundaries
            for (int i = 0; i < 6; i++)
            {
                boundarySprites.Add(content.Load<Texture2D>("Fence" + (1 + i)));
            }
            // Set the position of the boundaries
            spritePosition.X = GameWorld.ScreenSize.X / 2 + moveAmountX;
            spritePosition.Y = GameWorld.ScreenSize.Y / 2 + moveAmountY;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the boundaries
            Vector2 origin = new Vector2(boundarySprites[chosenSprite].Width / 2, boundarySprites[chosenSprite].Height / 2);
            spriteBatch.Draw(boundarySprites[chosenSprite], spritePosition, null, Color.White, 0, origin, 3, SpriteEffects.None, 0);
        }
    }
}
