using Microsoft.Xna.Framework;

namespace MonoGame3D;

public class GameComponent : Microsoft.Xna.Framework.GameComponent
{
    public GameComponent() : base(Engine.Instance) { }
    public GameComponent(Game game) : base(game) { }
}