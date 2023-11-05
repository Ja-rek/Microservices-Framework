using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    /// <summary>
    /// Checks if a value is negative and throws an exception if it is.
    /// </summary>
    /// <typeparam name="T">The type of the value to be checked.</typeparam>
    /// <param name="value">The value to be checked for negativity.</param>
    /// <param name="id">An optional identifier for the context in which the check is made (default is null).</param>
    /// <param name="message">An optional custom error message (default is null).</param>
    /// <param name="valueName">An optional parameter name (default is determined by the caller).</param>
    /// <param name="idName">An optional identifier parameter name (default is determined by the caller).</param>
    /// <exception cref="Exception">Thrown if the value is negative.</exception>
    public static void ThrowIfNegative<T>(
        T value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
        where T : struct, IComparable, IConvertible
    {
        if (value.CompareTo(default(T)) < 0)
        {
            var exception = Create<T>($"shouldn't be a negative number", message, id, valueName, idName);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}