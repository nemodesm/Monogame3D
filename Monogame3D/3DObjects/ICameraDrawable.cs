using Microsoft.Xna.Framework;

namespace MonoGame3D._3DObjects
{
    public interface ICameraDrawable
    {
        internal void Draw(GameTime gameTime, Camera camera);
    }
}