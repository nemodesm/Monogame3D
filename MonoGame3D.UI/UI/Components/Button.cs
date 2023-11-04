using System;
using System.Diagnostics.CodeAnalysis;

// TODO: button is not selectable
// TODO: button is not clickable

namespace MonoGame3D.UI.Components;

public class Button : SelectableUIComponent
{
    // TODO: add better summary
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
        /// Adds <paramref name="action"/> as an action that'll be called when the event gets triggered
        /// </summary>
        /// <param name="action">The listener to add</param>
        public void AddListener(Action action)
        {
            _action += action;
        }

        /// <summary>
        /// Removes <paramref name="action"/> as an action that'll be called when the event gets triggered
        /// </summary>
        /// <param name="action">The listener to remove</param>
        public void RemoveListener(Action action)
        {
            _action -= action;
        }

        /// <summary>
        /// Triggers the event
        /// </summary>
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
    
    /// <summary>
    /// Event that is called when the button is selected
    /// </summary>
    [NotNull]
    public readonly ButtonEvent OnSelect = new();
    
    /// <summary>
    /// Creates a new button
    /// </summary>
    /// <param name="selectAction">The action that will be called when the button is selected</param>
    /// <param name="submitAction">The action that will be called when the button is clicked</param>
    /// <param name="anchorPosition"></param>
    public Button(Action? selectAction = null, Action? submitAction = null)
    {
        OnSelect = new ButtonEvent(selectAction);
        OnSubmit = new ButtonEvent(submitAction);
    }
    public Button() { }

    /// <inheritdoc />
    public override void Select()
    {
        OnSelect.Invoke();
    }

    public override NavigationData NavigationData { get; set; }

    /// <inheritdoc />
    public override void Submit()
    {
        OnSubmit.Invoke();
    }
}