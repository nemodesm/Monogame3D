using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame3D._3DObjects;

namespace MonoGame3D;

public abstract class Engine : Game
{
    /// <summary>
    /// The current instance of the engine
    /// </summary>
    public static Engine Instance { get; private set; } = null!;
        
    /// <summary>
    /// The graphics device manager for the game
    /// </summary>
    public static GraphicsDeviceManager Graphics { get; private set; } = null!;

    /// <summary>
    /// The rendering camera for the game
    /// </summary>
    public static Camera Camera { get; private set; } = null!;

    /// <summary>
    /// TODO: Document
    /// </summary>
    public static float DeltaTime { get; private set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static Matrix ScreenMatrix { get; set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static int Width { get; private set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static int Height { get; private set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static int ViewWidth { get; private set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static int ViewHeight { get; private set; }
    /// <summary>
    /// TODO: Document
    /// </summary>
    public static int ViewPadding
    {
        get => _viewPadding;
        set
        {
            _viewPadding = value;
            Instance.UpdateView();
        }
    }
    /// <summary>
    /// TODO: Document
    /// </summary>
    private static int _viewPadding;

    private readonly EngineModule[] _modules;

    /// <summary>
    /// TODO: Document
    /// </summary>
    public static Viewport Viewport { get; private set; }

    /// <summary>
    /// Initialises the Engine and sets all relevant properties.
    /// </summary>
    protected Engine(params EngineModule[] modules) : base()
    {
        Instance = this;

        this._modules = modules;

        SetupGraphics();

        InitializeRootComponents();

        InitialiseModules();
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
        
        Components.Add(Camera);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
    
    // TODO: Cache which components are IUpdateable
    protected override void Update(GameTime gameTime)
    {
        DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

        // this._updateables.ForEachFilteredItem<GameTime>(UpdateAction, gameTime);
        foreach (var updateable in Components.Where(component => component is Microsoft.Xna.Framework.IUpdateable))
        {
            try
            {
                ((Microsoft.Xna.Framework.IUpdateable)updateable!).Update(gameTime);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    protected override void UnloadContent()
    {
        ContentManager.Unload();
        base.UnloadContent();
    }
    
    // TODO: Cache which components are IDrawable
    protected sealed override void Draw(GameTime gameTime)
    {
        // this._drawables.ForEachFilteredItem<GameTime>(Game.DrawAction, gameTime);
        foreach (var updateable in Components.Where(component => component is IDrawable))
        {
            try
            {
                ((IDrawable)updateable!).Draw(gameTime);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

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
        Viewport = new Viewport
        {
            X = (int)(screenWidth / 2 - ViewWidth / 2f),
            Y = (int)(screenHeight / 2 - ViewHeight / 2f),
            Width = ViewWidth,
            Height = ViewHeight,
            MinDepth = 0,
            MaxDepth = 1
        };

        //Debug Log
        //Calc.Log("Update View - " + screenWidth + "x" + screenHeight + " - " + viewport.Width + "x" + viewport.GuiHeight + " - " + viewport.X + "," + viewport.Y);
    }

    #region Modules

    private void InitialiseModules()
    {
        foreach (var engineModule in _modules)
        {
            this.Components.Add(engineModule);
        }
    }

    public T GetModule<T>() where T : EngineModule
    {
        foreach (var module in _modules)
        {
            if (module is T tModule)
            {
                return tModule;
            }
        }

        throw new Exception("Module not found");
    }

    public EngineModule GetModule(Type type)
    {
        foreach (var module in _modules)
        {
            if (module.GetType() == type)
            {
                return module;
            }
        }

        throw new Exception("Module not found");
    }

    #endregion
}