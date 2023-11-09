using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Content;

namespace ZooObjektorienteretProgram
{
    internal class AnimalBoundaries : GameObject
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
            this.chosenSprite = ChosenSprite;
            this.moveAmountX = MoveAmountX;
            this.moveAmountY = MoveAmountY;
            this.name = Name;
        }

        public override void LoadContent(ContentManager content)
        {
            for (int i = 0; i < 6; i++)
            {
                boundarySprites.Add(content.Load<Texture2D>("Fence" + (1 + i)));
            }

            spritePosition.X = GameWorld.ScreenSize.X / 2 + moveAmountX;
            spritePosition.Y = GameWorld.ScreenSize.Y / 2 + moveAmountY;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(boundarySprites[chosenSprite].Width / 2, boundarySprites[chosenSprite].Height / 2);
            spriteBatch.Draw(boundarySprites[chosenSprite], spritePosition, null, Color.White, 0, origin, 3, SpriteEffects.None, 0);
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                    (int)(spritePosition.X - boundarySprites[chosenSprite].Bounds.X / 2),
                    (int)(spritePosition.Y - boundarySprites[chosenSprite].Bounds.Y / 2),
                    (int)boundarySprites[chosenSprite].Bounds.X,
                    (int)boundarySprites[chosenSprite].Bounds.Y
                );
            }
        }
    }
}
