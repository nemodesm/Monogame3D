using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem.Mouse;

public static class Mouse
{
    private static MouseState _currentState;
    private static MouseState _previousState;
    
    static Mouse()
    {
        _currentState = new MouseState();
        _previousState = new MouseState();
    }
    
    public static Vector2 Position => new Vector2(_currentState.X, _currentState.Position.Y);

    public static Vector2 Delta => new Vector2(_currentState.X - _previousState.X, _currentState.Y - _previousState.Y);

    public static float X => _currentState.X;
    public static float Y => _currentState.Y;
    
    /// <summary>
    /// Updates the current state of the mouse
    /// </summary>
    /// <remarks>This function should be called once per frame, even if input is currently disabled</remarks>
    internal static void Update()
    {
        _previousState = _currentState;
        _currentState = Microsoft.Xna.Framework.Input.Mouse.GetState();
    }
}