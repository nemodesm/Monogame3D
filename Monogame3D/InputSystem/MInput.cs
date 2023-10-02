using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

// TODO: Add support for getting what gamepad is being used and get what prompt to show

// TODO: Add support for retrieving what input device is being used

/// <summary>
/// TODO: Add description
/// </summary>
public static partial class MInput
{
    public static KeyboardData? Keyboard { get; private set; }
    public static MouseData? Mouse { get; private set; }
    public static GamePadData[]? GamePads { get; private set; }

    internal static List<VirtualInput>? VirtualInputs;

    /// <summary>
    /// When false, disables registering input
    /// </summary>
    public static bool Active = true;
    /// <summary>
    /// Disables retrieving input
    /// </summary>
    public static bool Disabled = false;

    /// <summary>
    /// Initialises the different input devices
    /// </summary>
    internal static void Initialize()
    {
        //Init devices
        Keyboard = new KeyboardData();
        Mouse = new MouseData();
        GamePads = new GamePadData[4];
        for (var i = 0; i < 4; i++)
            GamePads[i] = new GamePadData((PlayerIndex)i);
        VirtualInputs = new List<VirtualInput>();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    internal static void Shutdown()
    {
        foreach (var gamepad in GamePads!)
            gamepad.StopRumble();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    internal static void Update()
    {
        if (Engine.Instance.IsActive && Active)
        {
            Keyboard!.Update();
            Mouse!.Update();

            for (var i = 0; i < 4; i++)
                GamePads![i].Update();
        }
        else
        {
            Keyboard!.UpdateNull();
            Mouse!.UpdateNull();
            for (var i = 0; i < 4; i++)
                GamePads![i].UpdateNull();
        }

        UpdateVirtualInputs();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static void UpdateNull()
    {
        Keyboard!.UpdateNull();
        Mouse!.UpdateNull();
        for (var i = 0; i < 4; i++)
            GamePads![i].UpdateNull();

        UpdateVirtualInputs();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    private static void UpdateVirtualInputs()
    {
        foreach (var virtualInput in VirtualInputs!)
            virtualInput.Update();
    }

    #region Helpers

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static void RumbleFirst(float strength, float time)
    {
        GamePads![0].Rumble(strength, time);
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static int Axis(bool negative, bool positive, int bothValue)
    {
        if (negative)
        {
            if (positive)
                return bothValue;
            return -1;
        }

        if (positive)
            return 1;
        return 0;
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static int Axis(float axisValue, float deadzone)
    {
        if (Math.Abs(axisValue) >= deadzone)
            return Math.Sign(axisValue);
        return 0;
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static int Axis(bool negative, bool positive, int bothValue, float axisValue, float deadzone)
    {
        var ret = Axis(axisValue, deadzone);
        if (ret == 0)
            ret = Axis(negative, positive, bothValue);
        return ret;
    }

    #endregion
}