using System;

namespace Monogame3D.Exceptions;

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