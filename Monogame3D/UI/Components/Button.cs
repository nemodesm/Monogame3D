using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D.InputSystem;

namespace Monogame3D.UI.Components
{
    public class Button : UIComponent, ISubmitHandler, ISelectable
    {
        /// <summary>
        /// A generic event 
        /// </summary>
        public class ButtonSelectEvent
        {
            private Action _action;

            public ButtonSelectEvent() { }
            internal ButtonSelectEvent(Action action)
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

        /// <summary>
        /// Whether or not the button can be clicked
        /// </summary>
        public bool IsSelectable => Enabled;

        /// <summary>
        /// 
        /// </summary>
        [NotNull]
        public ButtonSelectEvent OnSelect;

        public Button(Action selectAction, AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 size = default, Vector2 offset = default)
        {
            this.OnSelect = new ButtonSelectEvent(selectAction);
        }
        public Button()
        {
            this.OnSelect = new ButtonSelectEvent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO
        }

        public void OnSubmit()
        {
            OnSelect.Invoke();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void Deselect()
        {
            throw new NotImplementedException();
        }
    }
}
