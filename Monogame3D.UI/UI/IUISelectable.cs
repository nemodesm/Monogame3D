using MonoGame3D.InputSystem;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D.UI;

public interface IUISelectable : ISelectable
{
    public NavigationData NavigationData { get; }
}