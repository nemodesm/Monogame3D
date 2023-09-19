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

        protected Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            Debug.Initialise();

            Components.Add(new Camera(this));
            Components.Add(InputTracker.CreateInstance(this));

            base.Initialize();
        }
    }
}
