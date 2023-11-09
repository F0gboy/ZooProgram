using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal abstract class GameObject
    {
        private Texture2D sprite;
        private Vector2 position;

        public GameObject() { }

        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(SpriteBatch spriteBatch);

        public bool IsColliding(GameObject other)
        {
            if (this == other)
                return false;

            return CollisionBox.Intersects(other.CollisionBox);
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                    (int)(position.X - sprite.Bounds.X / 2),
                    (int)(position.Y - sprite.Bounds.Y / 2),
                    (int)sprite.Bounds.X,
                    (int)sprite.Bounds.Y
                );
            }
        }

    }
}
