using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
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