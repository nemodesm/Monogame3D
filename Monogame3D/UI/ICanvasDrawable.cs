using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI
{
    public interface ICanvasDrawable
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}