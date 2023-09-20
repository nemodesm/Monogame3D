using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame3D.InputSystem
{
    public interface ISelectable
    {
        public bool IsSelectable { get; }

        public void Select();
        public void DeSelect();
    }
}
