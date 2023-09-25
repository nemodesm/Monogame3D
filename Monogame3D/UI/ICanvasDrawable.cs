using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI;

public interface ICanvasDrawable
{
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}