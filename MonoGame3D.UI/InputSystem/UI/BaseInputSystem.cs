using Microsoft.Xna.Framework;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D.InputSystem.UI;

public abstract class BaseInputSystem : IUpdateable
{
    public UIEventManager? EventManager;
    protected bool IsActiveInputSystem;

    public BaseInputSystem() {}

    public virtual void RegisterEventManager(UIEventManager eventManager)
    {
        EventManager = eventManager;
        IsActiveInputSystem = true;
    }

    public virtual void DeregisterEventManager()
    {
        EventManager = null;
        IsActiveInputSystem = false;
    }

    public virtual void Move(MoveDirection direction)
    {
        EventManager?.MoveSelection(direction);
    }

    public abstract void Update(GameTime gameTime);
}