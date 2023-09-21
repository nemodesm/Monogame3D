using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Monogame3D.UI.Components
{
    public class Button : SelectableUIComponent
    {
        /// <summary>
        /// A generic event
        /// </summary>
        public class ButtonEvent
        {
            private Action _action;

            public ButtonEvent() { }
            internal ButtonEvent(Action action)
            {
                this._action = action;
            }

            /// <summary>
            /// Adds <paramref name="action"/> as an action that'll be called when the button gets selected
            /// </summary>
            /// <param name="action">The listener to add</param>
            public void AddListener(Action action)
            {
                _action += action;
            }

            /// <summary>
            /// Removes <paramref name="action"/> as an action that'll be called when the button gets selected
            /// </summary>
            /// <param name="action">The listener to remove</param>
            public void RemoveListener(Action action)
            {
                _action -= action;
            }

            public void Invoke()
            {
                _action?.Invoke();
            }
        }

        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Event that is called when the button is clicked
        /// </summary>
        [NotNull]
        public readonly ButtonEvent OnSubmit = new();

        private Vector2 _size;

        public Button(Action selectAction, Vector2 size = default, AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 offset = default)
        {
            this.OnSubmit = new ButtonEvent(selectAction);
            this._size = size;
            this.AnchorPosition = anchorPosition;
            this.Offset = offset;
        }
        public Button() { }

        /// <inheritdoc />
        public override void Select()
        {
            // TODO
        }

        /// <inheritdoc />
        public override void Submit()
        {
            OnSubmit.Invoke();
        }
    }
}
