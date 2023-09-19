using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public struct AxisDefinition
    {
        public Keys positive;
        public Keys negative;

        public static AxisDefinition Horizontal => new AxisDefinition(Keys.A, Keys.D);
        public static AxisDefinition Vertical => new AxisDefinition(Keys.S, Keys.W);

        public AxisDefinition(Keys negative, Keys positive)
        {
            this.positive = positive;
            this.negative = negative;
        }
    }
}
