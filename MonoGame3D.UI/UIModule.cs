using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame3D;
using Monogame3D.Input;
using MonoGame3D.UI;

namespace MonoGame3D.UI;

public class UIModule : InputModule
{
    /// <summary>
    /// The main UI Canvas for the game
    /// </summary>
    public Canvas Canvas { get; private set; } = null!;

    public UIModule()
    {
        Canvas = new Canvas();
    }

    public override void Initialize()
    {
        Canvas.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        Canvas.Update(gameTime);

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        Canvas.Draw(gameTime);

        base.Draw(gameTime);
    }
}

