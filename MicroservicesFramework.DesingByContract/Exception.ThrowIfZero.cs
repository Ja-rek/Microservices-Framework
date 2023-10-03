using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfZero(uint value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(int value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(ulong value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(long value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(ushort value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(short value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(byte value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }


    public static void ThrowIfZero(double value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(float value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    public static void ThrowIfZero(decimal value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        var exception = IfZero(value is 0, value, id, message, valueName, idName);
        if (exception != null)
        {
            throw exception;
        }
    }

    private static Exception? IfZero(bool argument,
        object value,
        object? id = null,
        string? message = null,
        string? valueName = null,
        string? idName = null)
    {
        if (argument)
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