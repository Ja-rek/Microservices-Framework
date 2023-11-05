using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    /// <summary>
    /// Checks if a value is less than a specified minimum value and throws an exception if it is.
    /// </summary>
    /// <typeparam name="T">The type of values to be compared.</typeparam>
    /// <param name="min">The minimum value that the input value should not be less than.</param>
    /// <param name="value">The value to be checked against the minimum value.</param>
    /// <param name="id">An optional identifier for the context in which the check is made (default is null).</param>
    /// <param name="message">An optional custom error message (default is null).</param>
    /// <param name="valueName">An optional parameter name (default is determined by the caller).</param>
    /// <param name="idName">An optional identifier parameter name (default is determined by the caller).</param>
    /// <exception cref="Exception">Thrown if the value is less than the minimum value.</exception>
    public static void ThrowIfLessThan<T>(T min,
        T value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
        where T : struct, IComparable, IConvertible
    {
        if (value.CompareTo(min) < 0)
        {
            var exception = Create<T>($"shouldn't be less than {min}", message, id, valueName, idName);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}