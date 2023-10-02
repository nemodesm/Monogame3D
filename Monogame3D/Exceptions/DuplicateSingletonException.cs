using System;
using System.Runtime.Serialization;

namespace MonoGame3D.Exceptions;

[Serializable]
public class DuplicateSingletonException : Exception
{
    public DuplicateSingletonException() { }
    public DuplicateSingletonException(string message) : base(message) { }
    public DuplicateSingletonException(string message, Exception inner) : base(message, inner) { }
    protected DuplicateSingletonException(
        SerializationInfo info,
        StreamingContext context) : base(info, context) { }
}