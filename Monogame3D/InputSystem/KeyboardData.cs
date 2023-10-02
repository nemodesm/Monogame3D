using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

public static partial class MInput
{
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
}