using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame3D.InputSystem;

/// <summary>
/// TODO: Add description
/// </summary>
public static class MInput
{
    public static KeyboardData Keyboard { get; private set; }
    public static MouseData Mouse { get; private set; }
    public static GamePadData[] GamePads { get; private set; }

    internal static List<VirtualInput> VirtualInputs;

    public static bool Active = true;
    public static bool Disabled = false;

    /// <summary>
    /// TODO: Add description
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
        foreach (var gamepad in GamePads)
            gamepad.StopRumble();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    internal static void Update()
    {
        if (Engine.Instance.IsActive && Active)
        {
            Keyboard.Update();
            Mouse.Update();

            for (var i = 0; i < 4; i++)
                GamePads[i].Update();
        }
        else
        {
            Keyboard.UpdateNull();
            Mouse.UpdateNull();
            for (var i = 0; i < 4; i++)
                GamePads[i].UpdateNull();
        }

        UpdateVirtualInputs();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static void UpdateNull()
    {
        Keyboard.UpdateNull();
        Mouse.UpdateNull();
        for (var i = 0; i < 4; i++)
            GamePads[i].UpdateNull();

        UpdateVirtualInputs();
    }

    /// <summary>
    /// TODO: Add description
    /// </summary>
    private static void UpdateVirtualInputs()
    {
        foreach (var virtualInput in VirtualInputs)
            virtualInput.Update();
    }

    #region Keyboard

    /// <summary>
    /// Handles keyboard input
    /// </summary>
    public class KeyboardData
    {
        /// <summary>
        /// The state of the keyboard last frame
        /// </summary>
        public KeyboardState PreviousState;
        /// <summary>
        /// The current state of the keyboard
        /// </summary>
        public KeyboardState CurrentState;

        internal KeyboardData()
        {
        }

        /// <summary>
        /// Updates the current state of the keyboard
        /// </summary>
        internal void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        /// <summary>
        /// Updates the current state of the keyboard with a null state
        /// </summary>
        internal void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = new KeyboardState();
        }

        #region Basic Checks

        /// <summary>
        /// Checks whether <paramref name="key"/> is pressed
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Whether the is key pressed</returns>
        public bool Check(Keys key)
        {
            return !Disabled && CurrentState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks whether <paramref name="key"/> was pressed this frame
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Whether the key was pressed this frame</returns>
        public bool Pressed(Keys key)
        {
            if (Disabled)
                return false;

            return CurrentState.IsKeyDown(key) && !PreviousState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks whether <paramref name="key"/> was released this frame
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Whether the key was released this frame</returns>
        public bool Released(Keys key)
        {
            if (Disabled)
                return false;

            return !CurrentState.IsKeyDown(key) && PreviousState.IsKeyDown(key);
        }

        #endregion

        #region Convenience Checks

        /// <summary>
        /// Checks whether any of the two keys are pressed
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <returns>Whether any of the keys is currently pressed</returns>
        public bool Check(Keys keyA, Keys keyB)
        {
            return Check(keyA) || Check(keyB);
        }

        /// <summary>
        /// Checks whether any of the two keys were pressed this frame
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <returns>Whether any of the keys were pressed this frame</returns>
        public bool Pressed(Keys keyA, Keys keyB)
        {
            return Pressed(keyA) || Pressed(keyB);
        }

        /// <summary>
        /// Checks whether any of the two keys were released this frame
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <returns>Whether any of the keys was released this frame</returns>
        public bool Released(Keys keyA, Keys keyB)
        {
            return Released(keyA) || Released(keyB);
        }

        /// <summary>
        /// Checks whether any of the three keys are pressed
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <param name="keyC">The third key to check</param>
        /// <returns>Whether any of the keys is currently pressed</returns>
        public bool Check(Keys keyA, Keys keyB, Keys keyC)
        {
            return Check(keyA) || Check(keyB) || Check(keyC);
        }

        /// <summary>
        /// Checks whether any of the three keys were pressed this frame
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <param name="keyC">The third key to check</param>
        /// <returns>Whether any of the keys were pressed this frame</returns>
        public bool Pressed(Keys keyA, Keys keyB, Keys keyC)
        {
            return Pressed(keyA) || Pressed(keyB) || Pressed(keyC);
        }

        /// <summary>
        /// Checks whether any of the three keys were released this frame
        /// </summary>
        /// <param name="keyA">The first key to check</param>
        /// <param name="keyB">The second key to check</param>
        /// <param name="keyC">The third key to check</param>
        /// <returns>Whether any of the keys was released this frame</returns>
        public bool Released(Keys keyA, Keys keyB, Keys keyC)
        {
            return Released(keyA) || Released(keyB) || Released(keyC);
        }

        #endregion

        #region Axis

        /// <summary>
        /// Checks the axis formed by <paramref name="negative"/> and <paramref name="positive"/>.
        /// </summary>
        /// <param name="negative">The key that will have a negative value</param>
        /// <param name="positive">The key that will have a positive value</param>
        /// <returns></returns>
        public int AxisCheck(Keys negative, Keys positive)
        {
            if (Check(negative))
            {
                if (Check(positive))
                    return 0;
                return -1;
            }

            if (Check(positive))
                return 1;
            return 0;
        }

        /// <summary>
        /// Checks the axis formed by <paramref name="negative"/> and <paramref name="positive"/>.
        ///
        /// If both keys are pressed, returns <paramref name="both"/>.
        /// </summary>
        /// <param name="negative">The key that will have a negative value</param>
        /// <param name="positive">The key that will have a positive value</param>
        /// <param name="both">The value to return if both <paramref name="negative"/> and <paramref name="positive"/>
        /// are pressed</param>
        /// <returns></returns>
        public int AxisCheck(Keys negative, Keys positive, int both)
        {
            if (Check(negative))
            {
                if (Check(positive))
                    return both;
                return -1;
            }

            return Check(positive) ? 1 : 0;
        }

        #endregion
    }

    #endregion

    #region Mouse

    /// <summary>
    /// Handles mouse input
    /// </summary>
    public class MouseData
    {
        public MouseState PreviousState;
        public MouseState CurrentState;

        internal MouseData()
        {
            PreviousState = new MouseState();
            CurrentState = new MouseState();
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        internal void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        internal void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = new MouseState();
        }

        #region Buttons

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool CheckLeftButton => CurrentState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool CheckRightButton => CurrentState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool CheckMiddleButton => CurrentState.MiddleButton == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool PressedLeftButton =>
            CurrentState.LeftButton == ButtonState.Pressed &&
            PreviousState.LeftButton == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool PressedRightButton =>
            CurrentState.RightButton == ButtonState.Pressed &&
            PreviousState.RightButton == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool PressedMiddleButton =>
            CurrentState.MiddleButton == ButtonState.Pressed &&
            PreviousState.MiddleButton == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool ReleasedLeftButton =>
            CurrentState.LeftButton == ButtonState.Released &&
            PreviousState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool ReleasedRightButton =>
            CurrentState.RightButton == ButtonState.Released &&
            PreviousState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool ReleasedMiddleButton =>
            CurrentState.MiddleButton == ButtonState.Released &&
            PreviousState.MiddleButton == ButtonState.Pressed;

        #endregion

        #region Wheel

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public int Wheel => CurrentState.ScrollWheelValue;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public int WheelDelta => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;

        #endregion

        #region Position

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool WasMoved =>
            CurrentState.X != PreviousState.X
            || CurrentState.Y != PreviousState.Y;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float X
        {
            get => Position.X;
            set => Position = new Vector2(value, Position.Y);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float Y
        {
            get => Position.Y;
            set => Position = new Vector2(Position.X, value);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 Position
        {
            get =>
                Vector2.Transform(new Vector2(CurrentState.X, CurrentState.Y),
                    Matrix.Invert(Engine.ScreenMatrix));

            set
            {
                var vector = Vector2.Transform(value, Engine.ScreenMatrix);
                Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)Math.Round(vector.X), (int)Math.Round(vector.Y));
            }
        }

        #endregion
    }

    #endregion

    #region GamePads

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public class GamePadData
    {
        public PlayerIndex PlayerIndex { get; private set; }
        public GamePadState PreviousState;
        public GamePadState CurrentState;
        public bool Attached;

        private float _rumbleStrength;
        private float _rumbleTime;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        internal GamePadData(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public void Update()
        {
            PreviousState = CurrentState;
            CurrentState = GamePad.GetState(PlayerIndex);
            Attached = CurrentState.IsConnected;

            if (_rumbleTime > 0)
            {
                _rumbleTime -= Engine.DeltaTime;
                if (_rumbleTime <= 0)
                    GamePad.SetVibration(PlayerIndex, 0, 0);
            }
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public void UpdateNull()
        {
            PreviousState = CurrentState;
            CurrentState = new GamePadState();
            Attached = GamePad.GetState(PlayerIndex).IsConnected;

            if (_rumbleTime > 0)
                _rumbleTime -= Engine.DeltaTime;

            GamePad.SetVibration(PlayerIndex, 0, 0);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public void Rumble(float strength, float time)
        {
            if (_rumbleTime <= 0 || strength > _rumbleStrength || (Math.Abs(strength - _rumbleStrength) < float.Epsilon && time > _rumbleTime))
            {
                GamePad.SetVibration(PlayerIndex, strength, strength);
                _rumbleStrength = strength;
                _rumbleTime = time;
            }
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public void StopRumble()
        {
            GamePad.SetVibration(PlayerIndex, 0, 0);
            _rumbleTime = 0;
        }

        #region Buttons

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Check(Buttons button)
        {
            if (Disabled)
                return false;

            return CurrentState.IsButtonDown(button);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Pressed(Buttons button)
        {
            if (Disabled)
                return false;

            return CurrentState.IsButtonDown(button) && PreviousState.IsButtonUp(button);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Released(Buttons button)
        {
            if (Disabled)
                return false;

            return CurrentState.IsButtonUp(button) && PreviousState.IsButtonDown(button);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Check(Buttons buttonA, Buttons buttonB)
        {
            return Check(buttonA) || Check(buttonB);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Pressed(Buttons buttonA, Buttons buttonB)
        {
            return Pressed(buttonA) || Pressed(buttonB);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Released(Buttons buttonA, Buttons buttonB)
        {
            return Released(buttonA) || Released(buttonB);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Check(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            return Check(buttonA) || Check(buttonB) || Check(buttonC);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Pressed(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            return Pressed(buttonA) || Pressed(buttonB) || Check(buttonC);
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool Released(Buttons buttonA, Buttons buttonB, Buttons buttonC)
        {
            return Released(buttonA) || Released(buttonB) || Check(buttonC);
        }

        #endregion

        #region Sticks

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 GetLeftStick()
        {
            var ret = CurrentState.ThumbSticks.Left;
            ret.Y = -ret.Y;
            return ret;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 GetLeftStick(float deadzone)
        {
            var ret = CurrentState.ThumbSticks.Left;
            if (ret.LengthSquared() < deadzone * deadzone)
                ret = Vector2.Zero;
            else
                ret.Y = -ret.Y;
            return ret;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 GetRightStick()
        {
            var ret = CurrentState.ThumbSticks.Right;
            ret.Y = -ret.Y;
            return ret;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 GetRightStick(float deadzone)
        {
            var ret = CurrentState.ThumbSticks.Right;
            if (ret.LengthSquared() < deadzone * deadzone)
                ret = Vector2.Zero;
            else
                ret.Y = -ret.Y;
            return ret;
        }

        #region Left Stick Directions

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X <= -deadzone && PreviousState.ThumbSticks.Left.X > -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X > -deadzone && PreviousState.ThumbSticks.Left.X <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X >= deadzone && PreviousState.ThumbSticks.Left.X < deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.X < deadzone && PreviousState.ThumbSticks.Left.X >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y <= -deadzone && PreviousState.ThumbSticks.Left.Y > -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y > -deadzone && PreviousState.ThumbSticks.Left.Y <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y >= deadzone && PreviousState.ThumbSticks.Left.Y < deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Left.Y < deadzone && PreviousState.ThumbSticks.Left.Y >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float LeftStickHorizontal(float deadzone)
        {
            var h = CurrentState.ThumbSticks.Left.X;
            if (Math.Abs(h) < deadzone)
                return 0;
            return h;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float LeftStickVertical(float deadzone)
        {
            var v = CurrentState.ThumbSticks.Left.Y;
            if (Math.Abs(v) < deadzone)
                return 0;
            return -v;
        }

        #endregion

        #region Right Stick Directions

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X <= -deadzone && PreviousState.ThumbSticks.Right.X > -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X > -deadzone && PreviousState.ThumbSticks.Right.X <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X >= deadzone && PreviousState.ThumbSticks.Right.X < deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.X < deadzone && PreviousState.ThumbSticks.Right.X >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y <= -deadzone && PreviousState.ThumbSticks.Right.Y > -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y > -deadzone && PreviousState.ThumbSticks.Right.Y <= -deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownCheck(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownPressed(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y >= deadzone && PreviousState.ThumbSticks.Right.Y < deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownReleased(float deadzone)
        {
            return CurrentState.ThumbSticks.Right.Y < deadzone && PreviousState.ThumbSticks.Right.Y >= deadzone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float RightStickHorizontal(float deadzone)
        {
            var h = CurrentState.ThumbSticks.Right.X;
            if (Math.Abs(h) < deadzone)
                return 0;
            return h;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float RightStickVertical(float deadzone)
        {
            var v = CurrentState.ThumbSticks.Right.Y;
            if (Math.Abs(v) < deadzone)
                return 0;
            return -v;
        }

        #endregion

        #endregion

        #region DPad

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public int DPadHorizontal =>
            CurrentState.DPad.Right == ButtonState.Pressed
                ? 1
                : CurrentState.DPad.Left == ButtonState.Pressed ? -1 : 0;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public int DPadVertical =>
            CurrentState.DPad.Down == ButtonState.Pressed
                ? 1
                : CurrentState.DPad.Up == ButtonState.Pressed ? -1 : 0;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public Vector2 DPad => new(DPadHorizontal, DPadVertical);

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadLeftCheck => CurrentState.DPad.Left == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadLeftPressed => CurrentState.DPad.Left == ButtonState.Pressed && PreviousState.DPad.Left == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadLeftReleased => CurrentState.DPad.Left == ButtonState.Released && PreviousState.DPad.Left == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadRightCheck => CurrentState.DPad.Right == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadRightPressed =>
            CurrentState.DPad.Right == ButtonState.Pressed &&
            PreviousState.DPad.Right == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadRightReleased =>
            CurrentState.DPad.Right == ButtonState.Released &&
            PreviousState.DPad.Right == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadUpCheck => CurrentState.DPad.Up == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadUpPressed => CurrentState.DPad.Up == ButtonState.Pressed && PreviousState.DPad.Up == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadUpReleased => CurrentState.DPad.Up == ButtonState.Released && PreviousState.DPad.Up == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadDownCheck => CurrentState.DPad.Down == ButtonState.Pressed;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadDownPressed => CurrentState.DPad.Down == ButtonState.Pressed && PreviousState.DPad.Down == ButtonState.Released;

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool DPadDownReleased => CurrentState.DPad.Down == ButtonState.Released && PreviousState.DPad.Down == ButtonState.Pressed;

        #endregion

        #region Triggers

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftTriggerCheck(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Left >= threshold;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftTriggerPressed(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Left >= threshold && PreviousState.Triggers.Left < threshold;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftTriggerReleased(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Left < threshold && PreviousState.Triggers.Left >= threshold;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightTriggerCheck(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Right >= threshold;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightTriggerPressed(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Right >= threshold && PreviousState.Triggers.Right < threshold;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightTriggerReleased(float threshold)
        {
            if (Disabled)
                return false;

            return CurrentState.Triggers.Right < threshold && PreviousState.Triggers.Right >= threshold;
        }

        #endregion
    }

    #endregion

    #region Helpers

    /// <summary>
    /// TODO: Add description
    /// </summary>
    public static void RumbleFirst(float strength, float time)
    {
        GamePads[0].Rumble(strength, time);
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