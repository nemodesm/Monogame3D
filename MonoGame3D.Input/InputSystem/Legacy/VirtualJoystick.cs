using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.MathUtils;

namespace MonoGame3D.InputSystem.Legacy;

/// <summary>
/// A virtual input that is represented as a Vector2, with both X and Y as values between -1 and 1
/// </summary>
public class VirtualJoystick : VirtualInput
{
    public List<Node> Nodes;
    public bool Normalized;
    public float? SnapSlices;

    public Vector2 Value { get; private set; }
    public Vector2 PreviousValue { get; private set; }

    public VirtualJoystick(bool normalized)
    {
        Nodes = new List<Node>();
        Normalized = normalized;
    }

    public VirtualJoystick(bool normalized, params Node[] nodes)
    {
        Nodes = new List<Node>(nodes);
        Normalized = normalized;
    }

    public override void Update()
    {
        foreach (var node in Nodes)
            node.Update();

        PreviousValue = Value;
        Value = Vector2.Zero;
        foreach (var node in Nodes)
        {
            var value = node.Value;
            if (value == Vector2.Zero) continue;
            if (Normalized)
            {
                if (SnapSlices.HasValue)
                    value = value.SnappedNormal(SnapSlices.Value);
                else
                    value.Normalize();
            }
            else if (SnapSlices.HasValue)
                value = value.Snapped(SnapSlices.Value);

            Value = value;
            break;
        }
    }

    public static implicit operator Vector2(VirtualJoystick joystick)
    {
        return joystick.Value;
    }

    public abstract class Node : VirtualInputNode
    {
        public abstract Vector2 Value { get; }
    }

    public class PadLeftStick : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadLeftStick(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override Vector2 Value => MInput.GamePads[GamepadIndex].GetLeftStick(Deadzone);
    }

    public class PadRightStick : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadRightStick(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override Vector2 Value => MInput.GamePads[GamepadIndex].GetRightStick(Deadzone);
    }

    public class PadDpad : Node
    {
        public int GamepadIndex;

        public PadDpad(int gamepadIndex)
        {
            GamepadIndex = gamepadIndex;
        }

        public override Vector2 Value
        {
            get
            {
                var value = Vector2.Zero;

                if (MInput.GamePads[GamepadIndex].DPadRightCheck)
                    value.X = 1f;
                else if (MInput.GamePads[GamepadIndex].DPadLeftCheck)
                    value.X = -1f;

                if (MInput.GamePads[GamepadIndex].DPadDownCheck)
                    value.Y = 1f;
                else if (MInput.GamePads[GamepadIndex].DPadUpCheck)
                    value.Y = -1f;

                return value;
            }
        }
    }

    public class KeyboardKeys : Node
    {
        public OverlapBehaviors OverlapBehavior;
        public Keys Left;
        public Keys Right;
        public Keys Up;
        public Keys Down;

        private bool _turnedX;
        private bool _turnedY;
        private Vector2 _value;

        public KeyboardKeys(OverlapBehaviors overlapBehavior, Keys left, Keys right, Keys up, Keys down)
        {
            OverlapBehavior = overlapBehavior;
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }

        public override void Update()
        {
            //X Axis
            if (MInput.Keyboard.Check(Left))
            {
                if (MInput.Keyboard.Check(Right))
                {
                    switch (OverlapBehavior)
                    {
                        default:
                        case OverlapBehaviors.CancelOut:
                            _value.X = 0;
                            break;

                        case OverlapBehaviors.TakeNewer:
                            if (!_turnedX)
                            {
                                _value.X *= -1;
                                _turnedX = true;
                            }

                            break;

                        case OverlapBehaviors.TakeOlder:
                            //X stays the same
                            break;
                    }
                }
                else
                {
                    _turnedX = false;
                    _value.X = -1;
                }
            }
            else if (MInput.Keyboard.Check(Right))
            {
                _turnedX = false;
                _value.X = 1;
            }
            else
            {
                _turnedX = false;
                _value.X = 0;
            }

            //Y Axis
            if (MInput.Keyboard.Check(Up))
            {
                if (MInput.Keyboard.Check(Down))
                {
                    switch (OverlapBehavior)
                    {
                        default:
                        case OverlapBehaviors.CancelOut:
                            _value.Y = 0;
                            break;

                        case OverlapBehaviors.TakeNewer:
                            if (!_turnedY)
                            {
                                _value.Y *= -1;
                                _turnedY = true;
                            }

                            break;

                        case OverlapBehaviors.TakeOlder:
                            //Y stays the same
                            break;
                    }
                }
                else
                {
                    _turnedY = false;
                    _value.Y = -1;
                }
            }
            else if (MInput.Keyboard.Check(Down))
            {
                _turnedY = false;
                _value.Y = 1;
            }
            else
            {
                _turnedY = false;
                _value.Y = 0;
            }
        }

        public override Vector2 Value => _value;
    }
}