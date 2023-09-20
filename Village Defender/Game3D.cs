using Microsoft.Xna.Framework;
using Monogame3D;
using Monogame3D._3DObjects;
using Monogame3D.UI;
using Monogame3D.UI.Components;

namespace VillageDefender
{
    internal class Game3D : Monogame3D.Engine
    {
        public Game3D() : base()
        {
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // base.Initialise should exceptionally be called before any other methods in this specific instance
            Canvas.AddElement(new UIElement(new Button(() => Debug.Log("Button Clicked")), new Image("defaultTexture", anchorPosition: AnchorPosition.Center)));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var renderer = new MeshRenderer(this, "MonoCube");
            
            ((LocalizedObject)renderer).Initialize();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
