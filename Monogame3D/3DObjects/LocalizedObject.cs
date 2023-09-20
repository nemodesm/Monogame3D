using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Monogame3D._3DObjects
{
    public class LocalizedObject : IGameComponent
    {
        protected readonly Engine game;

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Size;

        public Vector3 RotationEuler
        {
            get => QuaternionExtension.ToEulerAngles(Rotation);
            set => Rotation = QuaternionExtension.Euler(value);
        }

        protected LocalizedObject([NotNull] Engine game)
        {
            this.game = game;
        }

        public virtual void Initialize() { }
    }
}
