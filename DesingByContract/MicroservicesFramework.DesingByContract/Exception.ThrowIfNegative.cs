using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfNegative(uint value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(int value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(ulong value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(long value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(ushort value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(short value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(byte value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }


    public static void ThrowIfNegative(double value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(float value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNegative(decimal value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNegative(value < 0, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    private static Exception? IfNegative(bool argument,
        object value, 
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (argument)
        {
            var exception = ExceptionFactory($"shouldn't be negative number", value, message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}