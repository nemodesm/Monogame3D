using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D;

public static class Window
{
    private static GameWindow GameWindow => Engine.Instance.Window;
    private static GraphicsDevice GraphicsDevice => Engine.Instance.GraphicsDevice;
    private static GraphicsDeviceManager Graphics => Engine.Graphics;
    
    #region Position

    public static Vector2 Position
    {
        get => new Vector2(GameWindow.Position.X, GameWindow.Position.Y);
        set => GameWindow.Position = new Point((int)value.X, (int)value.Y);
    }

    #endregion

    #region Window Size

    public static int Width => GraphicsDevice.PresentationParameters.BackBufferWidth;
    public static int Height => GraphicsDevice.PresentationParameters.BackBufferHeight;

    public static Vector2 Size
    {
        set
        {
            Graphics.PreferredBackBufferWidth = (int)value.X;
            Graphics.PreferredBackBufferHeight = (int)value.Y;
            Graphics.ApplyChanges();
        }
        get =>
            new(Width, Height);
    }

    #endregion

    #region Fullscreen
    
    private static Vector2 lastNonFullscreenSize;

    public static bool IsFullscreen => Graphics.IsFullScreen;
    
    public static void ToggleFullscreen()
    {
        if (IsFullscreen)
            ExitFullscreen();
        else
            EnterFullscreen();
    }
    
    public static void ExitFullscreen()
    {
        Size = lastNonFullscreenSize;
        Graphics.IsFullScreen = false;
        Graphics.ApplyChanges();
        
        //Engine.Instance.UpdateView();
    }

    public static void EnterFullscreen()
    {
        lastNonFullscreenSize = Size;
        Graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        Graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        Graphics.IsFullScreen = true;
        Graphics.ApplyChanges();
        
        //Engine.Instance.UpdateView();
    }

    #endregion
}