using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
     public static void ThrowIfGreaterThan<T>(
        T min,
        T value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null)
        where T : struct, IComparable, IConvertible
    {
        if (value.CompareTo(min) > 0)
        {
            var exception = Create<T>($"shouldn't be greater than {min}", message, id, paramName, idName);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}