using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    /// <summary>
    /// Checks if a value is not within a specified range and throws an exception if it is.
    /// </summary>
    /// <typeparam name="T">The type of the value to be checked.</typeparam>
    /// <param name="min">The minimum allowed value in the range (inclusive).</param>
    /// <param name="max">The maximum allowed value in the range (inclusive).</param>
    /// <param name="value">The value to be checked against the range.</param>
    /// <param name="id">An optional identifier for the context in which the check is made (default is null).</param>
    /// <param name="message">An optional custom error message (default is null).</param>
    /// <param name="valueName">An optional parameter name (default is determined by the caller).</param>
    /// <param name="idName">An optional identifier parameter name (default is determined by the caller).</param>
    /// <exception cref="Exception">Thrown if the value is within the specified range.</exception>
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