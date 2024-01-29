using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem.Keyboard;

public class Keyboard
{
    private static KeyboardState _currentState;
    private static KeyboardState _previousState;
    
    static Keyboard()
    {
        _currentState = new KeyboardState();
        _previousState = new KeyboardState();
    }
    
    internal static void Update()
    {
        _previousState = _currentState;
        _currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
    }
}