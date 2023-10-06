using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using MonoGame3D.InputSystem;

namespace MonoGame3D.UI.Components;

public class Button : SelectableUIComponent
{
    /// <summary>
    /// A generic event
    /// </summary>
    public class ButtonEvent
    {
        private Action? _action;

        public ButtonEvent() { }
        internal ButtonEvent(Action? action)
        {
            _action = action;
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
    /// Event that is called when the button is clicked
    /// </summary>
    [NotNull]
    public readonly ButtonEvent OnSubmit = new();

    private Vector2 _size;

    public Button(Action? selectAction, Vector2 size = default, AnchorPosition anchorPosition = AnchorPosition.TopLeft)
    {
        OnSubmit = new ButtonEvent(selectAction);
        _size = size;
        AnchorPosition = anchorPosition;
    }
    public Button() { }

    /// <inheritdoc />
    public override void Select()
    {
        // TODO
    }

    public override NavigationData NavigationData { get; set; }

    /// <inheritdoc />
    public override void Submit()
    {
        OnSubmit.Invoke();
    }
}