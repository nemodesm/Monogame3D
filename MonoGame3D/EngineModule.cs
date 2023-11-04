using System;
using Microsoft.Xna.Framework;

namespace MonoGame3D
{
	public class EngineModule : GameComponent
    {
        public sealed override int UpdateOrder => 1000;

        public EngineModule()
		{
		}

        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}

