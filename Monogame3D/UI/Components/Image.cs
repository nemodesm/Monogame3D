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
    private Texture2D? _image;
    
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

    public Image(AnchorPosition anchorPosition = AnchorPosition.TopLeft) : this(
        "Engine\\defaultUIImage", anchorPosition)
    {
    }
    public Image(string imagePath, AnchorPosition anchorPosition = AnchorPosition.TopLeft)
    {
        this._imagePath = imagePath;
        if (anchorPosition == AnchorPosition.Absolute)
        {
            Debug.LogWarning($"Drawing {this} with absolute positioning, which is not recommended");
        }
        AnchorPosition = anchorPosition;
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
                spriteBatch.Draw(_image, Element!.Position, ColorTint);
                return;
            }

            spriteBatch.Draw(_image, Element!.ScaledPosition, ColorTint);
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