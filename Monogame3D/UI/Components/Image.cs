using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI.Components;

public class Image : UIComponent
{
    /// <summary>
    /// The texture that this image displays
    /// </summary>
    private Texture2D _image;
    
    /// <summary>
    /// The path to the texture that this image displays
    /// </summary>
    private string _imagePath;
    
    /// <summary>
    /// Tint that will be applied to the game
    /// </summary>
    public Color ColorTint = Color.White;

    /// <summary>
    /// The path to the texture that this image displays
    /// </summary>
    public string ImagePath
    {
        get => _imagePath;
        set
        {
            ContentManager.UnloadAsset(_imagePath, this);
            _imagePath = value;
            _image = ContentManager.RequestContent<Texture2D>(_imagePath, this);
        }
    }

    public Image(AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 offset = default) : this(
        "Engine\\defaultUIImage", anchorPosition, offset)
    {
    }
    public Image(string imagePath, AnchorPosition anchorPosition = AnchorPosition.TopLeft, Vector2 offset = default)
    {
        this._imagePath = imagePath;
        if (anchorPosition == AnchorPosition.Absolute)
        {
            Debug.LogWarning($"Drawing {this} with absolute positioning, which is not recommended");
        }
        AnchorPosition = anchorPosition;
        Offset = offset;
    }

    ~Image()
    {
        ContentManager.UnloadAsset(_imagePath, this);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        try
        {
            if (AnchorPosition == AnchorPosition.Absolute)
            {
                spriteBatch.Draw(_image, Offset, ColorTint);
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
                    _image.Width / 2,
                // ReSharper restore PossibleLossOfFraction
                AnchorPosition.TopRight or AnchorPosition.CenterRight or AnchorPosition.BottomRight => screenX -
                    _image.Width,
                _ => position.Y
            };
            position.Y = AnchorPosition switch
            {
                AnchorPosition.TopLeft or AnchorPosition.TopCenter or AnchorPosition.TopRight => 0,
                // ReSharper disable PossibleLossOfFraction
                AnchorPosition.CenterLeft or AnchorPosition.Center or AnchorPosition.CenterRight => screenY / 2 -
                    _image.Height / 2,
                // ReSharper restore PossibleLossOfFraction
                AnchorPosition.BottomLeft or AnchorPosition.BottomCenter or AnchorPosition.BottomRight => screenY -
                    _image.Height,
                _ => position.Y
            };

            spriteBatch.Draw(_image, position + Offset, ColorTint);
        }
        catch (ArgumentNullException e)
        {
            Debug.LogError(e);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(new NullReferenceException("Image is null, disabling component", e));
            this.Enabled = false;
        }
    }

    internal override void Initialise()
    {
        try
        {
            _image = ContentManager.RequestContent<Texture2D>(_imagePath, this);
        }
        catch (ContentLoadException e)
        {
            Debug.LogError(e);
        }
            
        base.Initialise();
    }
}