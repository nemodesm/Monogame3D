using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Monogame3D.MathUtils;

namespace Monogame3D.InputSystem;

/// <summary>
/// A virtual input represented as a float between -1 and 1
/// </summary>
public class VirtualAxis : VirtualInput
{
    public List<Node> Nodes;

    public float Value { get; private set; }
    public float PreviousValue { get; private set; }

    public VirtualAxis()
    {
        Nodes = new List<Node>();
    }

    public VirtualAxis(params Node[] nodes)
    {
        Nodes = new List<Node>(nodes);
    }

    public override void Update()
    {
        foreach (var node in Nodes)
            node.Update();

        PreviousValue = Value;
        Value = 0;
        foreach (var node in Nodes)
        {
            float value = node.Value;
            if (value != 0)
            {
                Value = value;
                break;
            }
        }
    }

    public static implicit operator float(VirtualAxis axis)
    {
        return axis.Value;
    }

    public abstract class Node : VirtualInputNode
    {
        public abstract float Value { get; }
    }

    public class PadLeftStickX : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadLeftStickX(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override float Value => Calc.SignThreshold(MInput.GamePads[GamepadIndex].GetLeftStick().X, Deadzone);
    }

    public class PadLeftStickY : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadLeftStickY(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override float Value => Calc.SignThreshold(MInput.GamePads[GamepadIndex].GetLeftStick().Y, Deadzone);
    }

    public class PadRightStickX : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadRightStickX(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override float Value => Calc.SignThreshold(MInput.GamePads[GamepadIndex].GetRightStick().X, Deadzone);
    }

    public class PadRightStickY : Node
    {
        public int GamepadIndex;
        public float Deadzone;

        public PadRightStickY(int gamepadIndex, float deadzone)
        {
            GamepadIndex = gamepadIndex;
            Deadzone = deadzone;
        }

        public override float Value => Calc.SignThreshold(MInput.GamePads[GamepadIndex].GetRightStick().Y, Deadzone);
    }

    public class PadDpadLeftRight : Node
    {
        public int GamepadIndex;

        public PadDpadLeftRight(int gamepadIndex)
        {
            GamepadIndex = gamepadIndex;
        }

        public override float Value
        {
            get
            {
                if (MInput.GamePads[GamepadIndex].DPadRightCheck)
                    return 1f;
                else if (MInput.GamePads[GamepadIndex].DPadLeftCheck)
                    return -1f;
                else
                    return 0;
            }
        }
    }

    public class PadDpadUpDown : Node
    {
        public int GamepadIndex;

        public PadDpadUpDown(int gamepadIndex)
        {
            GamepadIndex = gamepadIndex;
        }

        public override float Value
        {
            get
            {
                if (MInput.GamePads[GamepadIndex].DPadDownCheck)
                    return 1f;
                else if (MInput.GamePads[GamepadIndex].DPadUpCheck)
                    return -1f;
                else
                    return 0;
            }
        }
    }

    public class KeyboardKeys : Node
    {
        public OverlapBehaviors OverlapBehavior;
        public Keys Positive;
        public Keys Negative;

        private float _value;
        private bool _turned;

        public KeyboardKeys(OverlapBehaviors overlapBehavior, Keys negative, Keys positive)
        {
            OverlapBehavior = overlapBehavior;
            Negative = negative;
            Positive = positive;
        }

        public override void Update()
        {
            if (MInput.Keyboard.Check(Positive))
            {
                if (MInput.Keyboard.Check(Negative))
                {
                    switch (OverlapBehavior)
                    {
                        default:
                        case OverlapBehaviors.CancelOut:
                            _value = 0;
                            break;

                        case OverlapBehaviors.TakeNewer:
                            if (!_turned)
                            {
                                _value *= -1;
                                _turned = true;
                            }

                            break;

                        case OverlapBehaviors.TakeOlder:
                            //value stays the same
                            break;
                    }
                }
                else
                {
                    _turned = false;
                    _value = 1;
                }
            }
            else if (MInput.Keyboard.Check(Negative))
            {
                _turned = false;
                _value = -1;
            }
            else
            {
                _turned = false;
                _value = 0;
            }
        }

        public override float Value => _value;
    }
}