using MonoGame3D.InputSystem;

namespace MonoGame3D.UI;

public interface IUISelectable : ISelectable
{
    public NavigationData NavigationData { get; }
}