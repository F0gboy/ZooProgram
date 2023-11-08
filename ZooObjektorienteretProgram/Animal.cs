using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal abstract class Animal : GameObject
    {
        protected int health;
        protected float speed;
        protected int thirst;
        protected int hunger;
        protected Vector2 Velocity;
        protected float produce; 


        public Animal()
        {
            
        }

        public abstract void Move();

        
        public override void Draw(GameTime GameTime)
        {
             
        }

        public override void LoadContent(ContentManager content)
        {
            
        }
    }
}