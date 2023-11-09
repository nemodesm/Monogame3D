namespace MonoGame3D.InputSystem.Legacy;

public interface ISelectable
{
    public bool IsSelectable { get; }

    public void Select();
    
    public void Deselect();
}