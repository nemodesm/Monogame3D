using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Engine._3DObjects
{
    internal class LocalizedObject : IGameComponent
    {
        protected readonly Game game;

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Size;

        protected LocalizedObject([NotNull] Game game)
        {
            this.game = game;
        }

        public virtual void Initialize()
        {
            
        }
    }
}
