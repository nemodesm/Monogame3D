using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Monogame3D.InputSystem;

namespace Monogame3D
{
    public static class Input
    {
        public static bool GetKeyDown(Keys key)
        {
            return InputTracker.Instance.Current._keyboardState.IsKeyDown(key) &&
                InputTracker.Instance.PreviousFrame._keyboardState.IsKeyUp(key);
        }

        public static bool GetKey(Keys key)
        {
            return InputTracker.Instance.Current._keyboardState.IsKeyDown(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return InputTracker.Instance.Current._keyboardState.IsKeyUp(key) &&
                InputTracker.Instance.PreviousFrame._keyboardState.IsKeyDown(key);
        }

        public static float GetAxis(AxisDefinition axis)
        {
            var @out = 0f;
            if (GetKey(axis.negative)) @out--;
            if (GetKey(axis.positive)) @out++;
            return @out;
        }
    }
}
