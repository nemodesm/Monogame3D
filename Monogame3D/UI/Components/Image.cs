using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI.Components;

public class Image : UIComponent
{
    /// <summary>
    /// The texture that this image displays
    /// </summary>
    private Texture2D image;
    /// <summary>
    /// The path to the texture that this image displays
    /// </summary>
    private readonly string imagePath;
    /// <summary>
    /// Tint that will be applied to the game
    /// </summary>
    public Color ColorTint = Color.White;

    public Image(string imagePath, AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 offset = default)
    {
        this.imagePath = imagePath;
        if (anchorPosition == AnchorPosition.Absolute)
        {
            Debug.LogWarning($"Drawing {this} with absolute positioning");
        }
        AnchorPosition = anchorPosition;
        Offset = offset;
    }

    ~Image()
    {
        ContentManager.UnloadAsset(imagePath, this);
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

            var (screenX, screenY) = (Engine.Graphics.PreferredBackBufferWidth,
                Engine.Graphics.PreferredBackBufferHeight);
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

            spriteBatch.Draw(image, position + Offset, ColorTint);
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
            image = ContentManager.RequestContent<Texture2D>(imagePath, this);
        }
        catch (ContentLoadException e)
        {
            Debug.LogError(e);
        }
            
        base.Initialise();
    }
}