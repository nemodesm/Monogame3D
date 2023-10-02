using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

public static partial class MInput
{
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
}