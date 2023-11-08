using Microsoft.Xna.Framework;
using System;
using MonoGame3D;
using IUpdateable = Microsoft.Xna.Framework.IUpdateable;

public class GameComponent : IGameComponent, IUpdateable
{
    public GameComponent() : this(Engine.Instance) {}

    public GameComponent(Engine engine)
    {
        this.Engine = engine;
    }
    
    /// <summary>
    /// Easy lifetime check on objects
    /// </summary>
    /// <param name="component">The component to check</param>
    /// <returns>Whether the component is alive</returns>
    public static implicit operator bool(GameComponent? component) => component is not null;
    private bool _enabled = true;
    private int _updateOrder;

    public Engine Engine { get; private set; }

    public bool Enabled
    {
        get => this._enabled;
        set
        {
            if (this._enabled == value)
                return;
            this._enabled = value;
            this.OnEnabledChanged((object)this, EventArgs.Empty);
        }
    }

    public virtual int UpdateOrder
    {
        get => this._updateOrder;
        set
        {
            if (this._updateOrder == value)
                return;
            this._updateOrder = value;
            this.OnUpdateOrderChanged((object)this, EventArgs.Empty);
        }
    }

    public event EventHandler<EventArgs> EnabledChanged;

    public event EventHandler<EventArgs> UpdateOrderChanged;

    ~GameComponent() => this.Dispose(false);

    public virtual void Initialize()
    {
    }

    public virtual void Update(GameTime gameTime)
    {
    }

    protected virtual void OnUpdateOrderChanged(object sender, EventArgs args) => this.UpdateOrderChanged(sender, args);

    protected virtual void OnEnabledChanged(object sender, EventArgs args) => this.EnabledChanged(sender, args);

    protected virtual void Dispose(bool disposing)
    {
    }
}