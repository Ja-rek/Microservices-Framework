using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MicroFusion.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
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
}