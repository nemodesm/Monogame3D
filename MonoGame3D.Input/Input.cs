using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.InputSystem;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D;

public static class Input
{
    public static bool DisableUIInput { get; set; } = false;
    public static Vector2 mousePosition => MInput.Mouse.Position;

    public static bool GetKeyDown(Keys key)
    {
        try
        {
            return MInput.Keyboard.Pressed(key);
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
            return MInput.Keyboard.Check(key);
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
            return MInput.Keyboard.Released(key);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
            return false;
        }
    }

    public static float GetAxis(AxisDefinition axis)
    {
        var @out = 0f;
        if (GetKey(axis.negative)) @out--;
        if (GetKey(axis.positive)) @out++;
        return @out;
    }
}