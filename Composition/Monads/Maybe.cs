using System;

namespace Composition.Monads
{
	public static class Maybe
	{
		public static Maybe<T> FromValue<T>(T value)
		{
			throw new NotImplementedException("TODO Maybe");
		}

		public static Maybe<T> FromError<T>(Exception e)
		{
			throw new NotImplementedException("TODO Maybe");
		}

		public static Maybe<T> Result<T>(Func<T> f)
		{
			throw new NotImplementedException("TODO Maybe");
		}

		//TODO Maybe add SelectMany
	}

	public class Maybe<T>
	{
		public Maybe(Exception error, T value)
		{
			Error = error;
			Value = value;
		}

		public Exception Error { get; private set; }
		public T Value { get; private set; }
		public bool Success { get { return Error == null; } }
	}
}
