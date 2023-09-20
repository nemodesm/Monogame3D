using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame3D.InputSystem
{
    internal struct InputState
    {
        internal GamePadState _gamePadState;
        internal KeyboardState _keyboardState;
        internal MouseState _mouseState;

        public InputState()
        {
            _gamePadState = GamePad.GetState(PlayerIndex.One);
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
        }
        public InputState(PlayerIndex playerIndex)
        {
            _gamePadState = GamePad.GetState(playerIndex);
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
        }
    }
}