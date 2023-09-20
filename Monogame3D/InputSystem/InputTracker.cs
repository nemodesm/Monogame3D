using System;
using Microsoft.Xna.Framework;
using Monogame3D.Exceptions;

namespace Monogame3D.InputSystem
{
    internal class InputTracker : GameComponent
    {
        internal static InputTracker Instance;

        private InputState _current;
        private InputState _previousFrame;

        /// <summary>
        /// The InputState for the current frame
        /// </summary>
        public InputState Current => _current;
        /// <summary>
        /// The InputState for the previous frame
        /// </summary>
        public InputState PreviousFrame => _previousFrame;

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

        public override void Update(GameTime gameTime)
        {
            _previousFrame = _current;
            _current = new InputState();

            base.Update(gameTime);
        }
    }
}
