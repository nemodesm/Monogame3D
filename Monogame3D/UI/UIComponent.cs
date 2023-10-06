using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

/// <summary>
/// A component that can be attached to a UI Element and will receive calls to Draw and Update from the canvas
/// </summary>
public abstract class UIComponent : IUpdateable, ICanvasDrawable
{
    protected internal UIElement? UIElement { get; set; }
    protected Canvas Canvas => UIElement!.Canvas;
    protected static Engine Engine => Engine.Instance;
    private bool _initialized;

    private AnchorPosition _anchorPosition;
        
    public AnchorPosition AnchorPosition
    {
        get => _initialized ? UIElement!.AnchorPosition : _anchorPosition;
        set
        {
            if (_initialized)
            {
                UIElement!.AnchorPosition = value;
            }
            else
            {
                _anchorPosition = value;
            }
        }
    }

    public virtual bool Enabled
    {
        get => UIElement!.Enabled;
        set => UIElement!.Enabled = value;
    }

    public virtual int UpdateOrder => UIElement!.UpdateOrder;
    public event EventHandler<EventArgs>? EnabledChanged
    {
        add => UIElement!.EnabledChanged += value;
        remove => UIElement!.EnabledChanged -= value;
    }
    public event EventHandler<EventArgs>? UpdateOrderChanged
    {
        add => UIElement!.UpdateOrderChanged += value;
        remove => UIElement!.UpdateOrderChanged -= value;
    }

    public virtual void Update(GameTime gameTime) { }

    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    internal virtual void Initialise()
    {
        _initialized = true;
        AnchorPosition = _anchorPosition;
    }
}