using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public sealed class Canvas : UIElement, IGameComponent, IDrawable
{
    private SpriteBatch? _spriteBatch;

    public override AnchorPosition AnchorPosition => AnchorPosition.Center;
    public override Vector2 Offset => default;

    private bool initialized;

    internal Canvas()
    {
        Debug.Log("Initialised Canvas");
    }

    public void Draw(GameTime gameTime)
    {
        if (!initialized) Initialize();

        _spriteBatch!.Begin();
        foreach (var uiElement in ChildUIElements)
        {
            uiElement.Draw(gameTime, _spriteBatch);
        }
        _spriteBatch.End();
    }

    public new void Initialize()
    {
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        foreach (var uiElement in ChildUIElements)
        {
            uiElement.Initialize();
        }

        initialized = true;
    }

    public int DrawOrder => 1000;
    public bool Visible => true;
    public event EventHandler<EventArgs>? DrawOrderChanged;
    public event EventHandler<EventArgs>? VisibleChanged;

    // [Obsolete("Cannot add components to the root canvas object", true)]
    public override void AddComponent(UIComponent component) => Debug.LogError("Cannot add components to the root canvas object");
}