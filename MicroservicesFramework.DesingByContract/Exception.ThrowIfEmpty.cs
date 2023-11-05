using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    /// <summary>
    /// Checks if an IEnumerable is empty and throws an exception if it is.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IEnumerable.</typeparam>
    /// <param name="value">The IEnumerable to be checked for emptiness.</param>
    /// <param name="id">An optional identifier for the context in which the check is made (default is null).</param>
    /// <param name="message">An optional custom error message (default is null).</param>
    /// <param name="valueName">An optional parameter name (default is determined by the caller).</param>
    /// <param name="idName">An optional identifier parameter name (default is determined by the caller).</param>
    /// <exception cref="Exception">Thrown if the IEnumerable is empty.</exception>
    public static void ThrowIfEmpty<T>(IEnumerable<T> value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfEmpty<IEnumerable<T>>(!value.Any(), id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    /// <summary>
    /// Checks if a string is empty and throws an exception if it is.
    /// </summary>
    /// <param name="value">The string to be checked for emptiness.</param>
    /// <param name="id">An optional identifier for the context in which the check is made (default is null).</param>
    /// <param name="message">An optional custom error message (default is null).</param>
    /// <param name="valueName">An optional parameter name (default is determined by the caller).</param>
    /// <param name="idName">An optional identifier parameter name (default is determined by the caller).</param>
    /// <exception cref="Exception">Thrown if the string is empty.</exception>
    public static void ThrowIfEmpty(string value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfEmpty<string>(value == string.Empty, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }
    
    private static Exception? IfEmpty<T>(bool argument, 
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (argument == true)
        {
            var exception = Create<T>("shouldn't be empty", message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}