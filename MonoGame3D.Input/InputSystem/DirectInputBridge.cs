using Microsoft.Xna.Framework;
using SharpDX.DirectInput;

namespace MonoGame3D;

public class DirectInputBridge : GameComponent
{
    private static DirectInput _di = new DirectInput();

    public DirectInputBridge()
    {
        
    }

    public override void Initialize()
    {
        base.Initialize();
    }
    
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}