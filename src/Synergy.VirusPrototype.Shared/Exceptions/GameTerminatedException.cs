using System;
using System.Runtime.Serialization;

namespace Synergy.VirusPrototype.Shared.Exceptions
{
	[Serializable]
	public class GameTerminatedException : Exception
	{
		public GameTerminatedException()
		{
		}

		public GameTerminatedException(string message)
			: base(message)
		{
		}

		public GameTerminatedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected GameTerminatedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
