using System;

namespace Engine.Exceptions
{
	[Serializable]
	public class DuplicateSingletonException : Exception
	{
		public DuplicateSingletonException() { }
		public DuplicateSingletonException(string message) : base(message) { }
		public DuplicateSingletonException(string message, Exception inner) : base(message, inner) { }
		protected DuplicateSingletonException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
