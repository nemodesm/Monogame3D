using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

[Serializable]
public struct InputState : IUpdateable
{
    #region Classes

    public struct KeyboardState
    {
        public Keys[] PressedKeys = Array.Empty<Keys>();
        public Keys[] PressedKeysLastFrame = Array.Empty<Keys>();

        public KeyboardState() { }

        public bool GetKeyDown(Keys key)
        {
            return PressedKeys.Contains(key) && !PressedKeysLastFrame.Contains(key);
        }

        public bool GetKey(Keys key)
        {
            return PressedKeys.Contains(key);
        }

        public bool GetKeyUp(Keys key)
        {
            return !PressedKeys.Contains(key) && PressedKeysLastFrame.Contains(key);
        }

        public static KeyboardState GetState(InputState inputState)
        {
            var st = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            
            var keyboardState = new KeyboardState();

            keyboardState.PressedKeysLastFrame = inputState.Keyboard.PressedKeys;
            keyboardState.PressedKeys = st.GetPressedKeys();
            
            return keyboardState;
        }
    }
    
    public struct MouseState
    {
        public MouseButton[] PressedButtons = Array.Empty<MouseButton>();
        public MouseButton[] PressedButtonsLastFrame = Array.Empty<MouseButton>();

        public MouseState() { }

        public static MouseState GetState(InputState inputState)
        {
            var st = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
            var mouseState = new MouseState();
            
            var pressedButtons = new List<MouseButton>();
            if (st.LeftButton   == ButtonState.Pressed)  pressedButtons.Add(MouseButton.Left  );
            if (st.MiddleButton == ButtonState.Pressed)  pressedButtons.Add(MouseButton.Middle);
            if (st.RightButton  == ButtonState.Pressed)  pressedButtons.Add(MouseButton.Right );
            if (st.XButton1     == ButtonState.Pressed)  pressedButtons.Add(MouseButton.X1    );
            if (st.XButton2     == ButtonState.Pressed)  pressedButtons.Add(MouseButton.X2    );

            mouseState.PressedButtons = pressedButtons.ToArray();
            
            mouseState.PressedButtonsLastFrame = inputState.Mouse.PressedButtons;
            
            return mouseState;
        }
    }

    #endregion
    
    #region Fields
    
    public KeyboardState Keyboard;
    public MouseState Mouse;
    public GamePadSet GamePadStates;
    
    #endregion
    
    #region Methods
    
    public void Update(GameTime gameTime)
    {
        Keyboard = KeyboardState.GetState(this);
        Mouse = MouseState.GetState(this);
        GamePadStates = GamePadSet.GetState(this);
    }
    
    #endregion
}