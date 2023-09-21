using Microsoft.Xna.Framework;
using Monogame3D._3DObjects;
using Monogame3D.InputSystem;
using Monogame3D.UI;

namespace Monogame3D
{
    public abstract class Engine : Game
    {
        public static Engine Instance { get; private set; }
        
        public static GraphicsDeviceManager Graphics { get; private set; }

        public static Camera Camera { get; private set; }
        public static Canvas Canvas { get; private set; }

        protected Engine()
        {
            Instance = this;

            SetupGraphics();
            
            InitializeHelperClasses();

            InitializeRootComponents();
        }

        private void SetupGraphics()
        {
            Graphics = new GraphicsDeviceManager(this);

            IsFixedTimeStep = true;
            IsMouseVisible = true;
            
            Content.RootDirectory = "Content";
        }

        private void InitializeRootComponents()
        {
            Camera = new Camera();
            Canvas = new Canvas();
            
            Components.Add(Camera);
            Components.Add(Canvas);
            Components.Add(InputTracker.CreateInstance(this));
        }

        private void InitializeHelperClasses()
        {
            // Debug.Initialise();
        }

        protected override void Initialize()
        {
            Graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            Graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            Graphics.IsFullScreen = true;
            Graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void UnloadContent()
        {
            ContentManager.Unload();
            base.UnloadContent();
        }

        protected sealed override void Draw(GameTime gameTime) => base.Draw(gameTime);
    }
}
