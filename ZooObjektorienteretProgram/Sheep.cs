using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class Sheep : Animal
    {

        public int XPosition = 1;
        public int YPosition = 1; 

        public override void Move()
        {
            this.XPosition += 5; 
            this.YPosition += 5;
        }
        public override void LoadContent(ContentManager content)
        {
            sprite = new Texture2D[1];
            sprite[0] = content.Load<Texture2D>("sheep");
            Sheep sheep = new Sheep(); 

        }
        public override void Draw(GameTime GameTime)
        {
            base.Draw(GameTime);
            
        }
    }
    

}
