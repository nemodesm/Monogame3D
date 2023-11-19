using System.Linq;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.InputSystem.Legacy;

namespace MonoGame3D.InputSystem;

public readonly record struct Axis(Keys[] negative, Keys[] positive, int bothValue, float deadzone)
{
    public float Value => negative.Any(Input.GetKey) ? positive.Any(Input.GetKey) ? bothValue : -1 : positive.Any(Input.GetKey) ? 1 : 0;
}