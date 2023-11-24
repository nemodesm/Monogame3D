using Microsoft.Xna.Framework;
using MonoGame3D;
using MonoGame3D.InputSystem;
using MonoGame3D.InputSystem.Legacy;

// ReSharper disable once CheckNamespace
namespace MonoGame3D.Modules;

public class InputModule : EngineModule
{
    public override void Initialize()
    {
        MInput.Initialize();
        
        Input.Initialize();

        base.Initialize();
    }

    public override void Update(GameTime gameTime)
    {
        Input.Update();
        
        base.Update(gameTime);
    }
}

