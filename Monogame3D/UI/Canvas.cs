using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public sealed class Canvas : UIElement, IGameComponent, IDrawable
{
    public override string Name => "Canvas";

    private SpriteBatch? _spriteBatch;

    public override AnchorPosition AnchorPosition => AnchorPosition.Center;

    private bool _initialized;

    public override Rectangle Position => new(0, 0, 1920, 1080);

    public override Rectangle ScaledPosition => new(0, 0, Engine.Graphics.PreferredBackBufferWidth,
        Engine.Graphics.PreferredBackBufferHeight);

    internal Canvas()
    {
        Debug.Log("Initialised Canvas");
    }

    public void Draw(GameTime gameTime)
    {
        if (!_initialized) Initialize();

        _spriteBatch!.Begin();
        foreach (var uiElement in Children)
        {
            uiElement.Draw(gameTime, _spriteBatch);
        }
        _spriteBatch.End();
    }

    public new void Initialize()
    {
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        foreach (var uiElement in Children)
        {
            uiElement.Initialize();
        }

        _initialized = true;
    }

    private int _drawOrder = 1000;
    private bool _visible = true;
    public int DrawOrder
    {
        get => _drawOrder;
        private set
        {
            DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            _drawOrder = value;
        }
    }

    public bool Visible
    {
        get => _visible;
        private set
        {
            VisibleChanged?.Invoke(this, EventArgs.Empty);
            _visible = value;
        }
    }
    public event EventHandler<EventArgs>? DrawOrderChanged;
    public event EventHandler<EventArgs>? VisibleChanged;

    // [Obsolete("Cannot add components to the root canvas object", true)]
    public override void AddComponent(UIComponent component) => Debug.LogError("Cannot add components to the root canvas object");

    public override bool Raycast(Vector2 point, out UIElement? hit)
    {
        foreach (var child in Children)
        {
            if (child.Raycast(point, out hit))
            {
                return true;
            }
        }

        hit = null;
        return false;
    }
}