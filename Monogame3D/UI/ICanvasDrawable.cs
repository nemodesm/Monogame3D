using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public interface ICanvasDrawable
{
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}