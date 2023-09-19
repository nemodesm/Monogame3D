using System;
using Engine;
using Engine.Exceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VillageDefender.Input
{
    internal class InputTracker : GameComponent
    {
        private InputTracker() : base(null) => Debug.LogError(new ApplicationException());
        private InputTracker(Game game) : base(game)
        {
            if (Instance is not null)
                Debug.LogError(new DuplicateSingletonException());

            this.UpdateOrder = -100;
            Instance = this;
        }

        /// <summary>
        /// Alternative to <see cref="Initialise(Game)"/>
        /// </summary>
        /// <param name="game">The game that this will handle input for</param>
        /// <returns>The Input object that is created</returns>
        internal static InputTracker CreateInstance(Game game)
        {
            return new InputTracker(game);
        }

        /// <summary>
        /// Alternative to <see cref="CreateInstance(Game)"/>
        /// </summary>
        /// <param name="game">The game that this will handle input for</param>
        /// <returns>The Input object that is created</returns>
        internal static InputTracker Initialise(Game game) => CreateInstance(game);

        internal static InputTracker Instance;

        private InputState previousFrame;
        private InputState current;

        public Vector2 Movement
        {
            get
            {
                return new Vector2();
            }
        }

        public override void Update(GameTime gameTime)
        {
            previousFrame = current;
            current = new InputState();

            base.Update(gameTime);
        }
    }
}
