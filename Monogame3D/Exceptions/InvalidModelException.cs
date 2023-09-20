using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame3D.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException()
        {
        }

        public InvalidModelException(string message) : base(message)
        {
        }

        public InvalidModelException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
