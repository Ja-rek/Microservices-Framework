using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MicroFusion.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
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
}