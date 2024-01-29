using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem.Legacy;

public static partial class MInput
{
    /// <summary>
    /// TODO: Add description
    /// </summary>
    public class GamePadData
    {
        public PlayerIndex PlayerIndex { get; private set; }
        public Microsoft.Xna.Framework.Input.GamePadState PreviousState;
        public Microsoft.Xna.Framework.Input.GamePadState CurrentState;
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
            CurrentState = new Microsoft.Xna.Framework.Input.GamePadState();
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
        public Vector2 GetLeftStick(float deadZone)
        {
            var ret = CurrentState.ThumbSticks.Left;
            if (ret.LengthSquared() < deadZone * deadZone)
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
        public Vector2 GetRightStick(float deadZone)
        {
            var ret = CurrentState.ThumbSticks.Right;
            if (ret.LengthSquared() < deadZone * deadZone)
                ret = Vector2.Zero;
            else
                ret.Y = -ret.Y;
            return ret;
        }

        #region Left Stick Directions

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X <= -deadZone && PreviousState.ThumbSticks.Left.X > -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickLeftReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X > -deadZone && PreviousState.ThumbSticks.Left.X <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X >= deadZone && PreviousState.ThumbSticks.Left.X < deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickRightReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.X < deadZone && PreviousState.ThumbSticks.Left.X >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y <= -deadZone && PreviousState.ThumbSticks.Left.Y > -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickDownReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y > -deadZone && PreviousState.ThumbSticks.Left.Y <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y >= deadZone && PreviousState.ThumbSticks.Left.Y < deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool LeftStickUpReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Left.Y < deadZone && PreviousState.ThumbSticks.Left.Y >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float LeftStickHorizontal(float deadZone)
        {
            var h = CurrentState.ThumbSticks.Left.X;
            if (Math.Abs(h) < deadZone)
                return 0;
            return h;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float LeftStickVertical(float deadZone)
        {
            var v = CurrentState.ThumbSticks.Left.Y;
            if (Math.Abs(v) < deadZone)
                return 0;
            return -v;
        }

        #endregion

        #region Right Stick Directions

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X <= -deadZone && PreviousState.ThumbSticks.Right.X > -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickLeftReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X > -deadZone && PreviousState.ThumbSticks.Right.X <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X >= deadZone && PreviousState.ThumbSticks.Right.X < deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickRightReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.X < deadZone && PreviousState.ThumbSticks.Right.X >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y <= -deadZone && PreviousState.ThumbSticks.Right.Y > -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickUpReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y > -deadZone && PreviousState.ThumbSticks.Right.Y <= -deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownCheck(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownPressed(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y >= deadZone && PreviousState.ThumbSticks.Right.Y < deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public bool RightStickDownReleased(float deadZone)
        {
            return CurrentState.ThumbSticks.Right.Y < deadZone && PreviousState.ThumbSticks.Right.Y >= deadZone;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float RightStickHorizontal(float deadZone)
        {
            var h = CurrentState.ThumbSticks.Right.X;
            if (Math.Abs(h) < deadZone)
                return 0;
            return h;
        }

        /// <summary>
        /// TODO: Add description
        /// </summary>
        public float RightStickVertical(float deadZone)
        {
            var v = CurrentState.ThumbSticks.Right.Y;
            if (Math.Abs(v) < deadZone)
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
}