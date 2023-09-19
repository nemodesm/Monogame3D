using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Engine._3DObjects
{
    public class LocalizedObject : IGameComponent
    {
        protected readonly Game game;

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Size;

        public Vector3 RotationEuler
        {
            get => QuaternionExtension.ToEulerAngles(Rotation);
            set => Rotation = QuaternionExtension.Euler(value);
        }

        protected LocalizedObject([NotNull] Game game)
        {
            this.game = game;
        }

        public virtual void Initialize()
        {
            
        }
    }
}
