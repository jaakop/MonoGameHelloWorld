using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.GameObjects
{
    public interface IDrawable
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}
