using System;
using Microsoft.Xna.Framework;

namespace MonoGame3D
{
	public class EngineModule : GameComponent
    {
        public sealed override int UpdateOrder => 1000;
    }
}

