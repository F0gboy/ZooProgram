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
        private int boundarySize;
        private float spriteX = 50;
        private float spriteY = 50;
        private Vector2 spritePosition;
       

        public AnimalBoundaries(int BoundarySize) 
        { 
            this.boundarySize = BoundarySize;
            spritePosition.X = GameWorld.ScreenSize.X / 2;
            spritePosition.Y = GameWorld.ScreenSize.Y / 2;
        }


        public override void LoadContent(ContentManager content)
        {
            for (int i = 0; i < 6; i++)
            {
                boundarySprites.Add(content.Load<Texture2D>("Fence" + (1 + i)));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 origin = new Vector2(boundarySprites[1].Width / 2, boundarySprites[1].Height / 2);
                spriteBatch.Draw(boundarySprites[1], spritePosition , null, Color.White, 0, origin, 3, SpriteEffects.None, 0);
            }

        }
    }
}
