using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    private static string objectName { get; set; }

    static Exception()
    {
        objectName = typeof(TObject).Name;
    }

    public Exception()
    {
    }

    public Exception(string? message) : base(message)
    {
    }

    public Exception(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected Exception(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }


    public static void ThrowIf(bool value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (value) 
        {
            var exception = Create<bool>("shouldn't be true", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfTrue(bool value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (value) 
        {
            var exception = Create<bool>("shouldn't be true", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfFalse(bool value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (!value) 
        {
            var exception = Create<bool>("shouldn't be false", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfNotFound(TObject? argument, 
        object id, 
        string? message = null,
        [CallerArgumentExpression("id")] string? idName = null
        ) 
    {
        if (argument is null)
        {
            var exception = Create<TObject>($"{objectName} with {idName} {id} not found.", message);

            if (exception is not null)
            {
                throw exception;
            }
            else
            {
                throw new ApplicationException("Cannot create exception");
            }
        }
    }

    public static void ThrowIfNullOrEmpty(string? value,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            var exception = Create<string>("shouldn't not be null or empty", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfIsNullOrWhiteSpace(string? value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            var exception = Create<string>("shouldn't be null, empty or white space", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfNull(object? value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (value is null)
        {
            var exception = Create<object>("shouldn't be null", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfNotNull(object? value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (value is not null)
        {
            var exception = Create<object>("should be null", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfDefault<T>(T value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (EqualityComparer<T>.Default.Equals(value, default)) 
        {
            var exception = Create<T>("shouldn't be default", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    public static void ThrowIfNotDefault<T>(T value, 
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("value")] string? valueName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(value, default)) 
        {
            var exception = Create<T>("should be default", message, id, valueName, idName);
            if (exception != null) 
            { 
                throw exception; 
            }
        }
    }

    private static Exception? Create<T>(string partDefaultMessage,
        string? customeMessage = null,
        object? id = null,
        string? valueName = null,
        string? idName = null)
    {
        return ExceptionFactory<TException>.Create<T>(partDefaultMessage,
            objectName,
            customeMessage,
            id,
            valueName,
            idName);
    }

    //private static Exception? ExceptionFactory<T>(string? defaultMessage,
    //    string? customeMessage = null)
    //{
    //    if (defaultMessage is null)
    //    {
    //        throw new ApplicationException("No passed default exception message.");
    //    }

    //    var message = customeMessage is null
    //        ? defaultMessage
    //        : customeMessage;

    //    var exception = (TException?)Activator.CreateInstance(typeof(TException), new object[] { message });
    //    if (exception is not null)
    //    {
    //        return exception;
    //    }

    //    return new ApplicationException("Cannot create exception");
    //}
}