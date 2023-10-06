using System;
using Microsoft.Xna.Framework;

namespace MonoGame3D;

public abstract class GameElement : IUpdateable
{
    /// <summary>
    /// The name of this element
    /// </summary>
    /// <remarks>
    /// No checks are made to ensure that this name is unique
    /// </remarks>
    public virtual string Name { get; set; } = "Game Element";

    protected static Engine Engine => Engine.Instance;

    private bool _enabled = true;
    
    /// <summary>
    /// Whether this element is enabled
    /// </summary>
    /// <remarks>
    /// Inactive elements will not be drawn or updated
    /// </remarks>
    public bool Enabled
    {
        get => _enabled;
        set
        {
            EnabledChanged?.Invoke(this, EventArgs.Empty);
            _enabled = value;
        }
    }
    
    private int _updateOrder = 0;
    public int UpdateOrder
    {
        get => _updateOrder;
        protected init
        {
            UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            _updateOrder = value;
        }
    }
    public event EventHandler<EventArgs>? EnabledChanged;
    public event EventHandler<EventArgs>? UpdateOrderChanged;
    
    public virtual void Update(GameTime gameTime) { }

    public override string ToString()
    {
        return $"{Name} ({base.ToString()})";
    }
}