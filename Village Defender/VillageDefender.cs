using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame3D;

namespace VillageDefender;

// TODO: Create demo

/// <summary>
/// A demo game using the MonoGame3D engine
/// </summary>
internal class VillageDefender : Engine
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public VillageDefender()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Services.AddService(typeof(SpriteBatch), _spriteBatch);

        // TODO: use ContentManager.RequestContent<T> to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }
}