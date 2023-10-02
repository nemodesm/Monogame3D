using System;
using Microsoft.Xna.Framework;

namespace MonoGame3D.MathUtils;

public static class Calc
{
    #region Math

    public static float SignThreshold(float value, float threshold)
    {
        return Math.Abs(value) >= threshold ? Math.Sign(value) : 0;
    }


    public static Vector2 AngleToVector(float angleRadians, float length)
    {
        return new Vector2((float)Math.Cos(angleRadians) * length, (float)Math.Sin(angleRadians) * length);
    }

    #endregion

    #region Vector2

    public static float Angle(this Vector2 vector)
    {
        return (float)Math.Atan2(vector.Y, vector.X);
    }

    public static Vector2 SnappedNormal(this Vector2 vec, float slices)
    {
        var divider = MathHelper.TwoPi / slices;

        var angle = vec.Angle();
        angle = (float)Math.Floor((angle + divider / 2f) / divider) * divider;
        return AngleToVector(angle, 1f);
    }

    public static Vector2 Snapped(this Vector2 vec, float slices)
    {
        var divider = MathHelper.TwoPi / slices;

        var angle = vec.Angle();
        angle = (float)Math.Floor((angle + divider / 2f) / divider) * divider;
        return AngleToVector(angle, vec.Length());
    }

    #endregion
}