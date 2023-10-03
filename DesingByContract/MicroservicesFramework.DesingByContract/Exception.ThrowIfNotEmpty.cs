using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfNotEmpty<T>(IEnumerable<T> value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfNotEmpty(!value.Any(), id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfNotEmpty(string value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfNotEmpty(value == string.Empty, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }
    
    private static Exception? IfNotEmpty(bool value, 
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (value == false)
        {
            var exception = ExceptionFactory($"should be empty", value, message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}