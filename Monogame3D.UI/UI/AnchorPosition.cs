namespace MonoGame3D.UI;

/// <summary>
/// The position relative to the screen to anchor this UI Element
/// </summary>
public enum AnchorPosition
{
    /// <summary>
    /// Not anchored in any way, this is considered wildly unsafe due to how unreliable the position can be when
    /// changing UI scale and Viewport scale
    /// </summary>
    Absolute = 0x0,
    TopLeft = 0xA,
    TopCenter = 0xE,
    TopRight = 0x6,
    CenterLeft = 0xB,
    Center = 0xF,
    CenterRight = 0x7,
    BottomLeft = 0x9,
    BottomCenter = 0xD,
    BottomRight = 0x5
}