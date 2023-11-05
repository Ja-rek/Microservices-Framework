using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfNotRange<T>(T min,
        T max,
        T value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
        where T : struct, IComparable, IConvertible
    {
        if (!(value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0))
        {
            var exception = Create<T>($"should be in range {min} - {max}", message, id, valueName, idName);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}