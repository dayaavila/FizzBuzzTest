using System;

namespace FizzBuzzTest.CrossCutting.Exceptions
{
	[Serializable]
	public class FizzBuzzException : Exception
	{
		public FizzBuzzException()
		{
		}

		public FizzBuzzException(string message)
			: base(message)
		{
		}

		public FizzBuzzException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
