using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D;
using MonoGame3D._3DObjects;
using MonoGame3D.UI;
using MonoGame3D.UI.Components;

namespace VillageDefender;

/// <summary>
/// A debug "game" to test the engine, not meant for actual gameplay
/// </summary>
internal class Game3D : Engine
{
    protected override void Initialize()
    {
        Canvas.AddElement(new UIElement(
            new Button(submitAction: () => Debug.Log("Button Clicked")),
            new Image(anchorPosition: AnchorPosition.Center)));
        
        var child = new UIElement(
            new Button(submitAction: () => Debug.Log("Button Clicked")),
            new Image(anchorPosition: AnchorPosition.BottomLeft));
        Canvas.AddElement(child);
        
        var childofchild = new UIElement("Child of Child", new Rectangle(30, 30, 100, 100),
            new Button(submitAction: () => Debug.Log("Button Clicked")),
            new Image(anchorPosition: AnchorPosition.TopLeft));
        
        child.AddElement(childofchild);
        
        var childofchildofchild = new UIElement("Child of Child of Child", new Rectangle(0, 0, 50, 50),
            new Button(submitAction: () => Debug.Log("Button Clicked")),
            new Image(anchorPosition: AnchorPosition.Center));
        
        childofchild.AddElement(childofchildofchild);
        
        var childofchildofchild2 = new UIElement("Child of Child of Child", new Rectangle(0, 0, 50, 50),
            new Button(submitAction: () => Debug.Log("Button Clicked")),
            new Image(anchorPosition: AnchorPosition.TopCenter));
        
        childofchild.AddElement(childofchildofchild2);
            
        base.Initialize();
    }

    protected override void LoadContent()
    {
        var renderer = new MeshRenderer("MonoCube");
            
        renderer.Initialize();

        base.LoadContent();
    }

    private bool removed;
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        // Remove element after 1 second to test asset unloading
        if (!removed && gameTime.TotalGameTime.Seconds > 1)
        {
            removed = true;
            // Remove second child to test removing element with children
            Canvas.RemoveElement(Canvas.GetChild(1));
            Debug.Log("Removed UI Element");
        }
        
        Camera.Position.X += 0.01f;
            
        // Really aggressive garbage collection to make sure no assets are unintentionally unloaded in destructors
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            
        base.Update(gameTime);
    }
}