using System.Linq;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D.InputSystem;

public readonly record struct Axis(Keys[] negative, Keys[] positive, int bothValue = 0, float deadzone = 0.05f)
{
    public float Value
    {
        get
        {
            return negative.Any(Input.GetKey) ? positive.Any(Input.GetKey) ? bothValue : -1 :
                positive.Any(Input.GetKey) ? 1 : 0;
        }
    }
}