using Microsoft.Xna.Framework;

namespace MonoGame3D;

public class GameComponent : Microsoft.Xna.Framework.GameComponent
{
    public GameComponent() : base(Engine.Instance) { }
    public GameComponent(Game game) : base(game) { }
    
    /// <summary>
    /// Easy lifetime check on objects
    /// </summary>
    /// <param name="component">The component to check</param>
    /// <returns>Whether the component is alive</returns>
    public static implicit operator bool(GameComponent? component) => component is not null;
}