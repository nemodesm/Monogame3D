using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefender._3DObjects
{
    internal interface ICameraDrawable
    {
        internal void Draw(GameTime gameTime, Camera camera);
    }
}
