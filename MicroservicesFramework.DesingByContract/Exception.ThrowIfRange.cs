using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfRange(int min, 
        int max,
        uint value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min,
        int max,
        int value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min, 
        int max,
        ulong value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min, 
        int max,
        long value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min,
        int max,
        ushort value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min, 
        int max,
        short value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min,
        int max,
        byte value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }


    public static void ThrowIfRange(int min,
        int max,
        double value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min,
        int max,
        float value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null) 
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null) 
        { 
            throw exception; 
        }
    }

    public static void ThrowIfRange(int min,
        int max,
        decimal value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfRange(min, max, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }
    
    public static Exception? IfRange(
        int min,
        int max,
        IComparable value,
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null) 
    {
        if (value.CompareTo(min) > 0 || value.CompareTo(min) < 0)
        {
            var exception = ExceptionFactory($"shouldn't be in range {min} - {max}", value, message, id, valueName, idName);
            if (exception != null) 
            { 
                return exception; 
            }
        }

        return null;
    }
}