using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfGreaterThan(int min, 
        uint value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min,
        int value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min, 
        ulong value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min, 
        long value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min,
        ushort value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min, 
        short value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min,
        byte value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }


    public static void ThrowIfGreaterThan(int min,
        double value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min,
        float value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfGreaterThan(int min,
        decimal value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfGreaterThan(min, value, id, message, paramName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }
    
    private static Exception? IfGreaterThan(int min, 
        IComparable value,
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (value.CompareTo(min) < 0)
        {
            var exception = ExceptionFactory("shouldn't be greater than {min}", value, message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}