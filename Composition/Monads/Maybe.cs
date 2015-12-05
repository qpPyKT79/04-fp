using System;

namespace Composition.Monads
{
	public static class Maybe
	{
		public static Maybe<T> FromValue<T>(T value)=>new Maybe<T>(null, value);
		public static Maybe<T> FromError<T>(Exception e) => new Maybe<T>(e, default(T));

	    public static Maybe<T> Result<T>(Func<T> f)
	    {
	        try
	        {
                return FromValue(f());
            }
	        catch (Exception e)
	        {
	            return FromError<T>(e);
	        }
	    }
        public static Maybe<TOut> SelectMany<TIn,TSome, TOut>(
            this Maybe<TIn> monad,
            Func<TIn,TSome> f,
            Func<TIn,TSome, TOut> f1)
        {
            if (!monad.Success)
                return FromError<TOut>(monad.Error);
            return Result(() => f1(monad.Value, f(monad.Value)));
        }
        public static Maybe<TOut> SelectMany<TIn, TOut>(this Maybe<TIn> monad, Func<TIn,TOut> f )
        {
            if (monad.Success)
                return Result(() => f(monad.Value));
            return FromError<TOut>(monad.Error);
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
