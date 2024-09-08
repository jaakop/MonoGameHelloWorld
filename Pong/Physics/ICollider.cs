using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Physics
{
    internal interface ICollidable<T> where T : class
    {
        public bool CollidesWith(T other);
    }
}
