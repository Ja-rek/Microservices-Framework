using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfNotZero<T>(T value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
        where T : struct, IComparable, IConvertible
    {
        if (value.CompareTo(default(T)) != 0)
        {
            var exception = Create<T>($"should be zero", message, id, valueName, idName);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}