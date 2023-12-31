﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal abstract class GameObject
    {    
        private Texture2D sprite;
        protected Vector2 position1;
        protected Vector2 position2;

        protected Texture2D[] sprites;
        protected Vector2 position;
        protected float animationSpeed;
        private float animationTime;
        protected float scale = 1f;
        protected float rotation = 0f;

        //get current sprite
        private Texture2D CurrentSprite
        {
            get
            {
                return sprites[(int)animationTime];
            }
        }

        //get sprite size
        protected Vector2 SpriteSize
        {
            get
            {
                return new Vector2(CurrentSprite.Width * scale, CurrentSprite.Height * scale); 
            }
        }


        public GameObject() { }

        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(SpriteBatch spriteBatch);

        
    }
}
