using System.Runtime.CompilerServices;

namespace MicroFusion.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
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
}