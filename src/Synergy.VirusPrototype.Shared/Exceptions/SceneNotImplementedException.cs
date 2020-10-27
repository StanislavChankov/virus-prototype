using System;
using System.Runtime.Serialization;

namespace Synergy.VirusPrototype.Shared.Exceptions
{
	[Serializable]
	public class SceneNotImplementedException : NotImplementedException
	{
		public SceneNotImplementedException()
		{
		}

		public SceneNotImplementedException(string message)
			: base(message)
		{
		}

		public SceneNotImplementedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SceneNotImplementedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
