using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D._3DObjects;
using Monogame3D.InputSystem;
using Monogame3D.UI;

namespace Monogame3D
{
    public abstract class Engine : Game
    {
        /// <summary>
        /// The current instance of the engine
        /// </summary>
        public static Engine Instance { get; private set; }
        
        /// <summary>
        /// The graphics device manager for the game
        /// </summary>
        public static GraphicsDeviceManager Graphics { get; private set; }

        /// <summary>
        /// The rendering camera for the game
        /// </summary>
        public static Camera Camera { get; private set; }
        /// <summary>
        /// The main UI Canvas for the game
        /// </summary>
        public static Canvas Canvas { get; private set; }

        public static float DeltaTime { get; private set; }
        public static Matrix ScreenMatrix { get; set; }
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static int ViewWidth { get; private set; }
        public static int ViewHeight { get; private set; }
        public static int ViewPadding
        {
            get { return viewPadding; }
            set
            {
                viewPadding = value;
                Instance.UpdateView();
            }
        }
        private static int viewPadding = 0;
        private static bool resizing;
        public static Viewport Viewport { get; private set; }

        // time

        /// <summary>
        /// Initialises the Engine and sets all relevant properties.
        /// </summary>
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
            MInput.Initialize();
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

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            
            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            ContentManager.Unload();
            base.UnloadContent();
        }

        protected sealed override void Draw(GameTime gameTime) => base.Draw(gameTime);
        
        
        private void UpdateView()
        {
            float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            // get View Size
            if (screenWidth / Width > screenHeight / Height)
            {
                ViewWidth = (int)(screenHeight / Height * Width);
                ViewHeight = (int)screenHeight;
            }
            else
            {
                ViewWidth = (int)screenWidth;
                ViewHeight = (int)(screenWidth / Width * Height);
            }

            // apply View Padding
            var aspect = ViewHeight / (float)ViewWidth;
            ViewWidth -= ViewPadding * 2;
            ViewHeight -= (int)(aspect * ViewPadding * 2);

            // update screen matrix
            ScreenMatrix = Matrix.CreateScale(ViewWidth / (float)Width);

            // update viewport
            Engine.Viewport = new Viewport
            {
                X = (int)(screenWidth / 2 - ViewWidth / 2),
                Y = (int)(screenHeight / 2 - ViewHeight / 2),
                Width = ViewWidth,
                Height = ViewHeight,
                MinDepth = 0,
                MaxDepth = 1
            };

            //Debug Log
            //Calc.Log("Update View - " + screenWidth + "x" + screenHeight + " - " + viewport.Width + "x" + viewport.GuiHeight + " - " + viewport.X + "," + viewport.Y);
        }
    }
}
