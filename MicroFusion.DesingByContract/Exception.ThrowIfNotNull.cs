using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MicroFusion.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
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
}