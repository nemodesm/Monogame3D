using System;
using Microsoft.Xna.Framework;
using MonoGame3D.UI;

// ReSharper disable once CheckNamespace
namespace MonoGame3D.Modules;

public class UIModule : InputModule, IDrawable
{
    #region IDrawable

    public int DrawOrder => 1000;
    public bool Visible => true;
    public event EventHandler<EventArgs>? DrawOrderChanged;
    public event EventHandler<EventArgs>? VisibleChanged;

    #endregion
    
    /// <summary>
    /// The main UI Canvas for the game
    /// </summary>
    public Canvas Canvas { get; private set; }

    public UIModule() : base()
    {
        Canvas = new Canvas();
    }

    public override void Initialize()
    {
        Canvas.Initialize();
        
        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        Canvas.Update(gameTime);

        base.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        Canvas.Draw(gameTime);
    }
}

