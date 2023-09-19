using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine._3DObjects;
using Engine.InputSystem;
using Microsoft.Xna.Framework;

namespace Engine
{
    public abstract class Engine : Game
    {
        protected internal readonly GraphicsDeviceManager _graphics;

        public Camera Camera { get; private set; }

        protected Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            Debug.Initialise();

            Camera = new Camera(this);
            Components.Add(Camera);
            Components.Add(InputTracker.CreateInstance(this));

            base.Initialize();
        }

        protected sealed override void Draw(GameTime gameTime) => base.Draw(gameTime);
    }
}
