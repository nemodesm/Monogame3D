using Microsoft.Xna.Framework;
using Monogame3D._3DObjects;
using Monogame3D.InputSystem;
using Monogame3D.UI;

namespace Monogame3D
{
    public abstract class Engine : Game
    {
        protected internal readonly GraphicsDeviceManager Graphics;

        public Camera Camera { get; private set; }
        public Canvas Canvas { get; private set; }

        protected Engine()
        {
            Graphics = new GraphicsDeviceManager(this);

            IsFixedTimeStep = true;
            IsMouseVisible = true;
            
            Content.RootDirectory = "Content";
            
            InitializeHelperClasses();

            InitializeRootComponents();
        }

        private void InitializeRootComponents()
        {
            Camera = new Camera(this);
            Canvas = new Canvas(this);
            
            Components.Add(Camera);
            Components.Add(Canvas);
            Components.Add(InputTracker.CreateInstance(this));
        }

        private void InitializeHelperClasses()
        {
            Debug.Initialise();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected sealed override void Draw(GameTime gameTime) => base.Draw(gameTime);
    }
}
