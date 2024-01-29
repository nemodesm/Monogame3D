using System;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

public readonly record struct Binding(BindingType Type, Keys[]? Keys = default, Axis? horizontal = default, Axis? vertical = default)
{
    public bool IsPressed()
    {
        switch (Type)
        {
            case BindingType.Button:
                return Keys!.Any(Input.GetKey);
            case BindingType.Axis:
                return horizontal!.Value.Value != 0;
            case BindingType.Axis2D:
                return horizontal!.Value.Value != 0 || vertical!.Value.Value != 0;
            default:
                throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
        }
    }

    public bool WasPressedThisFrame() => Keys.Any(Input.GetKeyDown);
    public bool WasReleasedThisFrame() => Keys.Any(Input.GetKeyUp);
}