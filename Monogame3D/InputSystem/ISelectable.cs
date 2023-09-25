namespace Monogame3D.InputSystem;

public interface ISelectable
{
    public bool IsSelectable { get; }

    public void Select();
    
    public void Deselect();
}