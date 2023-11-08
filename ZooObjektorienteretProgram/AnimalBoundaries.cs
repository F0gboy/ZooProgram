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

        private void LoadContent(ContentManager content)
        {
            for (int i = 0; i < boundarySprites.Count; i++)
            {
                this.boundarySprites[i] = content.Load<Texture2D>(i + 1 + "Fence");
            }
        }

        private void DrawBoundary(GameTime gameTime)
        {
            for(int i = 0;i < boundarySprites.Count;i++) 
            {
              //  _spriteBatch.Draw(boundarySprites[i], position, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);

            }

        }
    }
}
