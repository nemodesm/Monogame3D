using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D.InputSystem;

namespace Monogame3D.UI;

public class SelectableUIComponent : UIComponent, ISelectable, ISubmitHandler
{
    // TODO: make abstract
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

    public virtual bool IsSelectable { get; protected set; }
    public void Select()
    {
        throw new System.NotImplementedException();
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }

    public void OnSubmit()
    {
        throw new System.NotImplementedException();
    }
}