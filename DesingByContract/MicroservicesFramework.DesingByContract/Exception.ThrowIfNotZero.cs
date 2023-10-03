using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfNotZero(uint value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(int value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(ulong value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(long value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(ushort value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(short value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(byte value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }


    public static void ThrowIfNotZero(double value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(float value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfNotZero(decimal value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfNotZero(value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }
    
    private static Exception? IfNotZero(IComparable value,
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (value.CompareTo(0) is not 0)
        {
            var exception = ExceptionFactory($"should be zero", value, message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}