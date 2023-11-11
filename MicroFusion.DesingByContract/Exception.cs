using System.Runtime.Serialization;

namespace MicroFusion.DesingByContract;

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

    public static Exception? Create<T>(string partDefaultMessage,
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
}