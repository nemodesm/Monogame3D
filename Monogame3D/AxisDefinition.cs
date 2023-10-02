using Microsoft.Xna.Framework.Input;

namespace MonoGame3D;

public struct AxisDefinition
{
    public Keys positive;
    public Keys negative;

    public static AxisDefinition Horizontal => new(Keys.A, Keys.D);
    public static AxisDefinition Vertical => new(Keys.S, Keys.W);

    public AxisDefinition(Keys negative, Keys positive)
    {
        this.positive = positive;
        this.negative = negative;
    }
}