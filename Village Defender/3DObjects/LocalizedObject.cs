using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace VillageDefender._3DObjects
{
    internal class LocalizedObject : IGameComponent
    {
        protected readonly Game game;

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Size;

        protected LocalizedObject([NotNull] Game game)
        {
            game.Components.Add(this);
            this.game = game;
        }

        public virtual void Initialize()
        {
            
        }
    }
}
