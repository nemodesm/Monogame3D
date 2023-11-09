using System;
using Microsoft.Xna.Framework;
using MonoGame3D.Exceptions;
using MonoGame3D.InputSystem.Legacy;
using MonoGame3D.UI;

namespace MonoGame3D.InputSystem.UI;

public class UIEventManager : GameComponent
{
    private BaseInputSystem? _controllingInputSystem;
    private IUISelectable? _currentSelected;
    
    public static UIEventManager? Current
    {
        get; 
        protected set;
    }

    public BaseInputSystem? ControllingInputSystem
    {
        get => _controllingInputSystem;
        set
        {
            _controllingInputSystem?.DeregisterEventManager();
            _controllingInputSystem = value;
            _controllingInputSystem?.RegisterEventManager(this);
        }
    }
    public IUISelectable? CurrentSelected
    {
        get => _currentSelected;
        set
        {
            _currentSelected?.Deselect();
            _currentSelected = value;
            _currentSelected?.Select();
        }
    }

    public UIEventManager() { }
    public UIEventManager(IUISelectable firstSelected)
    {
        CurrentSelected = firstSelected;
    }
    
    public static UIEventManager Init()
    {
        if (Current is not null)
        {
            throw new DuplicateSingletonException("Cannot create multiple UIEventManagers");
        }
        
        return Current = new UIEventManager();
    }
    
    public static void Init(IUISelectable firstSelected)
    {
        Current = new UIEventManager(firstSelected);
    }

    public void MoveSelection(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                if (CurrentSelected?.NavigationData.Up is not null && CurrentSelected.IsSelectable)
                {
                    CurrentSelected = CurrentSelected.NavigationData.Up;
                }
                break;
            case MoveDirection.Down:
                if (CurrentSelected?.NavigationData.Down is not null && CurrentSelected.IsSelectable)
                {
                    CurrentSelected = CurrentSelected.NavigationData.Down;
                }
                break;
            case MoveDirection.Left:
                if (CurrentSelected?.NavigationData.Left is not null && CurrentSelected.IsSelectable)
                {
                    CurrentSelected = CurrentSelected.NavigationData.Left;
                }
                break;
            case MoveDirection.Right:
                if (CurrentSelected?.NavigationData.Right is not null && CurrentSelected.IsSelectable)
                {
                    CurrentSelected = CurrentSelected.NavigationData.Right;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public override void Update(GameTime gameTime)
    {
        ControllingInputSystem?.Update(gameTime);
    }
}