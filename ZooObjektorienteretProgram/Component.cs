﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZooObjektorienteretProgram
{
    public abstract class Component
    {
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}

