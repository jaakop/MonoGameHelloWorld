using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using Pong.Physics;

namespace Pong.GameObjects
{
    public class GameObject : IDrawable, ICollidable<GameObject>
    {
        private Texture2D sprite;
        private Point position;
        private Point size;

        public Point Position
        {
            get => position; 
            set => position = value;
        }

        public GameObject(Texture2D sprite, Point size)
        {
            this.sprite = sprite;

            this.size = size;
            position = new Point(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle(position, size), Color.White);
        }

        public bool CollidesWith(GameObject other)
        {
            Rectangle ownRect = new Rectangle(position, size);
            Rectangle otherRect = new Rectangle(other.position, other.size);

            return ownRect.Intersects(otherRect);
        }
    }
}
