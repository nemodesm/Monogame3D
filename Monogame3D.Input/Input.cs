using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.InputSystem;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D;

public static class Input
{
    public static bool DisableUIInput { get; set; } = false;
    
    /// <inheritdoc cref="InputState.MouseState.Position"/>
    public static Vector2 mousePosition => InputState.Mouse.Position;
    
    internal static InputState InputState;

    public static bool GetKeyDown(Keys key)
    {
        try
        {
            return InputState.Keyboard.GetKeyDown(key);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
            return false;
        }
    }

    public static bool GetKey(Keys key)
    {
        try
        {
            return InputState.Keyboard.GetKey(key);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
            return false;
        }
    }

    public static bool GetKeyUp(Keys key)
    {
        try
        {
            return InputState.Keyboard.GetKeyUp(key);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
            return false;
        }
    }

    public static float GetAxis(Axis axis)
    {
        return axis.Value;
    }
    
    internal static void Update()
    {
        MInput.Update();
    }

    public static void Initialize()
    {
        InputState = new InputState();
    }
}