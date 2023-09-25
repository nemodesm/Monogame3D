using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D.InputSystem;

namespace Monogame3D.UI;

/// <summary>
/// A UI component that con be selected via button navigation or by clicking it
/// </summary>
public abstract class SelectableUIComponent : UIComponent, IUISelectable, ISubmitHandler
{
    /// <summary>
    /// Whether or not the component is selectable
    /// </summary>
    public virtual bool IsSelectable => Enabled;

    public abstract NavigationData NavigationData { get; set; }

    // TODO: make abstract
    /// <summary>
    /// Draw the component renderers
    /// </summary>
    /// <param name="gameTime">The time since the game start</param>
    /// <param name="spriteBatch">The spritebatch used to render the entire UI</param>
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

    /// <summary>
    /// Called when the user deselects this component.
    /// The two primary causes for this to be called is if the user selects another component or if this component is
    /// clicked (see <see cref="Monogame3D.UI.SelectableUIComponent.Submit()"/> for when this object is clicked)
    /// </summary>
    public virtual void Deselect() { }

    /// <summary>
    /// Called when this item is selected, that is, if the mouse is hovering on top of it or it is the currently focused
    /// component when using a controller.
    /// </summary>
    public abstract void Select();
    
    /// <summary>
    /// Called when this item is clicked.
    /// </summary>
    public abstract void Submit();
}