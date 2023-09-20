using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI.Components
{
    public class Image : UIComponent
    {
        private Texture2D image;
        private readonly string imagePath;
        /// <summary>
        /// Tint that will be applied to the game
        /// </summary>
        public Color ColorTint = Color.White;

        public Image() : this("defaultTexture") { }
        public Image(string imagePath, AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 offset = default)
        {
            this.imagePath = imagePath;
            this.AnchorPosition = anchorPosition;
            this.Offset = offset;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            try
            {
                if (AnchorPosition == AnchorPosition.Absolute)
                {
                    spriteBatch.Draw(image, Offset, ColorTint);
                    return;
                }

                var (screenX, screenY) = (Canvas.Engine.Graphics.PreferredBackBufferWidth,
                    Canvas.Engine.Graphics.PreferredBackBufferHeight);
                Vector2 position = default;
                position.X = AnchorPosition switch
                {
                    AnchorPosition.TopLeft or AnchorPosition.CenterLeft or AnchorPosition.BottomLeft => 0,
                    // ReSharper disable PossibleLossOfFraction
                    AnchorPosition.TopCenter or AnchorPosition.Center or AnchorPosition.BottomCenter => screenX / 2 -
                        image.Width / 2,
                    // ReSharper restore PossibleLossOfFraction
                    AnchorPosition.TopRight or AnchorPosition.CenterRight or AnchorPosition.BottomRight => screenX -
                        image.Width,
                    _ => position.Y
                };
                position.Y = AnchorPosition switch
                {
                    AnchorPosition.TopLeft or AnchorPosition.TopCenter or AnchorPosition.TopRight => 0,
                    // ReSharper disable PossibleLossOfFraction
                    AnchorPosition.CenterLeft or AnchorPosition.Center or AnchorPosition.CenterRight => screenY / 2 -
                        image.Height / 2,
                    // ReSharper restore PossibleLossOfFraction
                    AnchorPosition.BottomLeft or AnchorPosition.BottomCenter or AnchorPosition.BottomRight => screenY -
                        image.Height,
                    _ => position.Y
                };

                spriteBatch.Draw(image, position, ColorTint);
            }
            catch (ArgumentNullException e)
            {
                Debug.LogError(e);
            }
        }

        internal override void Initialise()
        {
            try
            {
                image = Canvas.Engine.Content.Load<Texture2D>(imagePath);
            }
            catch (ContentLoadException e)
            {
                Debug.LogError(e);
            }
            
            base.Initialise();
        }
    }
}
