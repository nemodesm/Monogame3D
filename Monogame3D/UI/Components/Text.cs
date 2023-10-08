using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI.Components;

public class Text : UIComponent
{
    private readonly string _fontPath;
    private SpriteFont _font;
    private string _text;
    private bool enableSizeControls;

    public Color ColorTint { get; set; }

    public string text
    {
        get => _text;
        set
        {
            _text = value;
            RecalculateBounds();
        }
    }

    public Text(string text, Color colorTint) : this(fontPath: "Engine\\defaultFont", text: text, colorTint: colorTint) { }
    
    public Text(string fontPath, string text, Color colorTint)
    {
        this._fontPath = fontPath;
        this._text = text;
        this.ColorTint = colorTint;
        this._font = ContentManager.RequestContent<SpriteFont>(this._fontPath, this);
    }
    
    ~Text()
    {
        ContentManager.UnloadAsset(_fontPath, this);
    }

    internal override void Initialise()
    {
        if (Position.Width == -1 || Position.Height == -1)
        {
            enableSizeControls = true;
            
            RecalculateBounds();
        }
        
        base.Initialise();
    }

    private void RecalculateBounds()
    {
        if (!enableSizeControls)
        {
            return;
        }
        
        var size = _font.MeasureString(text);

        var rectangle = Position;
        rectangle.Width = (int)size.X;
        rectangle.Height = (int)size.Y;
        Position = rectangle;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
// Finds the center of the string in coordinates inside the text rectangle
        Vector2 textSize = _font.MeasureString(text);
// Places text in center of the screen
        
        var pos = ScaledPosition;

        var scale = enableSizeControls ? Element.ScreenScale : new Vector2(pos.Width / textSize.X, pos.Height / textSize.Y);
        
        spriteBatch.DrawString(_font, text, new Vector2(pos.X, pos.Y), ColorTint, 0, new Vector2(0),
            scale, SpriteEffects.None, 0.5f);
    }
}