using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class AnimalBoundaries
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle rectangle;
        private List<Texture2D> boundarySprites;
        private int boundarySize;

        public AnimalBoundaries(int BoundarySize, List<Texture2D> BoundarySprites) 
        { 
            boundarySize = BoundarySize;
            this.boundarySprites = BoundarySprites;
        }
    }
}
