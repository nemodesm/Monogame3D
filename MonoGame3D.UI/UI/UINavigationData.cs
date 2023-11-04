namespace MonoGame3D.UI;


public struct NavigationData
{
    public IUISelectable? Up = null;
    public IUISelectable? Down = null;
    public IUISelectable? Left = null;
    public IUISelectable? Right = null;

    public NavigationData() { }

    public NavigationData(IUISelectable up, IUISelectable down, IUISelectable left, IUISelectable right)
    {
        Up = up;
        Down = down;
        Left = left;
        Right = right;
    }
}