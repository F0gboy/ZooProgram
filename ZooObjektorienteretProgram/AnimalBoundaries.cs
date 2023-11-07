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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle rectangle;
        private List<Texture2D> boundarySprites = new List<Texture2D>(6);
        private int boundarySize;

        public AnimalBoundaries(int BoundarySize, List<Texture2D> BoundarySprites, SpriteBatch spriteBatch) 
        { 
            this.boundarySize = BoundarySize;
            this.boundarySprites = BoundarySprites;
            this._spriteBatch = spriteBatch;
        }


        public override void LoadContent(ContentManager content)
        {
            for (int i = 0; i < boundarySprites.Count; i++)
            {
                this.boundarySprites[i] = content.Load<Texture2D>(i + 1 + "Fence");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < boundarySprites.Count; i++)
            {
                Vector2 origin = new Vector2(boundarySprites[i].Width / 2, boundarySprites[i].Height / 2);
                _spriteBatch.Draw(boundarySprites[i], Vector2.Zero, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);
            }
        }
    }
}
