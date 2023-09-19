using Microsoft.Xna.Framework;

namespace Engine._3DObjects
{
    public interface ICameraDrawable
    {
        internal void Draw(GameTime gameTime, Camera camera);
    }
}
