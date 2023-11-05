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
        var exception = IfNotEmpty<IEnumerable<T>>(!value.Any(), id, message, valueName, idName);
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
        var exception = IfNotEmpty<string>(value == string.Empty, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }
    
    private static Exception? IfNotEmpty<T>(bool value, 
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (value == false)
        {
            var exception = Create<T>($"should be empty", message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}