using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

/// <summary>
/// A component that can be attached to a UI Element and will receive calls to Draw and Update from the canvas
/// </summary>
public abstract class UIComponent : IUpdateable, ICanvasDrawable
{
    protected internal UIElement? Element { get; set; }
    protected Canvas Canvas => Element!.Canvas;
    protected static Engine Engine => Engine.Instance;
    private bool _initialized;

    private AnchorPosition? _anchorPosition { get; set; } = null;
        
    public AnchorPosition AnchorPosition
    {
        get => _initialized ? Element!.AnchorPosition : _anchorPosition ?? AnchorPosition.Absolute;
        set
        {
            if (_initialized)
            {
                Element!.AnchorPosition = value;
            }
            else
            {
                _anchorPosition = value;
            }
        }
    }
    
    public Rectangle Position
    {
        get => Element!.Position;
        set => Element!.Position = value;
    }
    
    public Rectangle ScaledPosition => Element!.ScaledPosition;

    public virtual bool Enabled
    {
        get => Element!.Enabled;
        set => Element!.Enabled = value;
    }

    public virtual int UpdateOrder => Element!.UpdateOrder;
    public event EventHandler<EventArgs>? EnabledChanged
    {
        add => Element!.EnabledChanged += value;
        remove => Element!.EnabledChanged -= value;
    }
    public event EventHandler<EventArgs>? UpdateOrderChanged
    {
        add => Element!.UpdateOrderChanged += value;
        remove => Element!.UpdateOrderChanged -= value;
    }

    public virtual void Update(GameTime gameTime) { }

    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    internal virtual void Initialise()
    {
        _initialized = true;
        if (_anchorPosition is not null)
        {
            AnchorPosition = _anchorPosition.Value;
        }
    }
}