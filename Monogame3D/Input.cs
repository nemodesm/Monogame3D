using Microsoft.Xna.Framework.Input;
using Monogame3D.InputSystem;

namespace Monogame3D
{
    public static class Input
    {
        public static bool GetKeyDown(Keys key)
        {
            return MInput.Keyboard.Pressed(key);
        }

        public static bool GetKey(Keys key)
        {
            return MInput.Keyboard.Check(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return MInput.Keyboard.Released(key);
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
