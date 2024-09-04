using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;

namespace Pong.GameObjects
{
    public class GameObject : IDrawable
    {
        private Texture2D sprite;
        private Point position;
        private Point size;

        public GameObject(Texture2D sprite, Point size)
        {
            this.sprite = sprite;

            this.size = size;
            position = new Point(100, 100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle(position, size), Color.White);
        }
    }
}
