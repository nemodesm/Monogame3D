using Microsoft.Xna.Framework;
using MonoGame3D;
using MonoGame3D.InputSystem.Legacy;

// ReSharper disable once CheckNamespace
namespace MonoGame3D.Modules;

public class InputModule : EngineModule
{
    public override void Initialize()
    {
        MInput.Initialize();

        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        MInput.Update();
        
        base.Update(gameTime);
    }
}

