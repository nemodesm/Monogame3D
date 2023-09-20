using System;
using Microsoft.Xna.Framework;

namespace Monogame3D
{
    internal static class QuaternionExtension
    {
        public static Quaternion Euler(Vector3 vector) // roll (x), pitch (Y), yaw (z)
        {
            var cr = MathF.Cos(vector.X * 0.5f);
            var sr = MathF.Sin(vector.X * 0.5f);
            var cp = MathF.Cos(vector.Y * 0.5f);
            var sp = MathF.Sin(vector.Y * 0.5f);
            var cy = MathF.Cos(vector.Z * 0.5f);
            var sy = MathF.Sin(vector.Z * 0.5f);

            return new Quaternion(cr * cp * cy + sr * sp * sy, sr * cp * cy - cr * sp * sy,
                cr * sp * cy + sr * cp * sy, cr * cp * sy - sr * sp * cy);
        }

        public static Vector3 ToEulerAngles(Quaternion q)
        {
            return new Vector3
            (
                MathF.Atan2(2 * (q.X * q.Y + q.Z * q.W), 1 - 2 * (q.Y * q.Y + q.Z * q.Z)),
                2 * MathF.Atan2(MathF.Sqrt(1 + 2 * (q.X * q.X - q.Y * q.W)), MathF.Sqrt(1 - 2 * (q.X * q.X - q.Y * q.W))) - MathF.PI / 2,
                MathF.Atan2(2 * (q.X * q.W + q.Y * q.Z), 1 - 2 * (q.Z * q.Z + q.W * q.W))
            );
        }
    }
}
