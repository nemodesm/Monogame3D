using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Monogame3D;
using Monogame3D._3DObjects;
using Monogame3D.UI;
using Monogame3D.UI.Components;

namespace VillageDefender
{
    internal class Game3D : Monogame3D.Engine
    {
        public Game3D() { }

        protected override void Initialize()
        {
            Canvas.AddElement(new UIElement(
                new Button(() => Debug.Log("Button Clicked")),
                new Image("defaultTexture", anchorPosition: AnchorPosition.Center)));
            Canvas.AddElement(new UIElement(
                new Button(() => Debug.Log("Button Clicked")),
                new Image("defaultTexture", anchorPosition: AnchorPosition.BottomLeft, new Vector2(30))));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var renderer = new MeshRenderer("MonoCube");
            
            renderer.Initialize();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        private bool removed = false;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (!removed && gameTime.TotalGameTime.Seconds > 1)
            {
                removed = true;
                Canvas.RemoveElement(Canvas.GetChild(0));
                Debug.Log("Removed UI Element");
            }
            
            // Really aggressive garbage collection to make sure no assets are unintentionally unloaded in destructors
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
            
            base.Update(gameTime);
        }
    }
}
