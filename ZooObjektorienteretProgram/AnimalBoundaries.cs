using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

namespace ZooObjektorienteretProgram
{
    internal class AnimalBoundaries
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle rectangle;
        private List<Texture2D> boundarySprites = new List<Texture2D>(6);
        private int boundarySize;

        public AnimalBoundaries(int BoundarySize, List<Texture2D> BoundarySprites) 
        { 
            this.boundarySize = BoundarySize;
            this.boundarySprites = BoundarySprites;
        }

        private void LoadContent(ContentManager content)
        {
            for (int i = 0; i < boundarySprites.Count; i++)
            {
                boundarySprites[i] = content.Load<Texture2D>(i + 1 + "Fence");
            }
        }

        private void DrawBoundary(GameTime gameTime)
        {
            
        }
    }
}
