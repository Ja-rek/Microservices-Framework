using System.Runtime.CompilerServices;

namespace MicroservicesFramework.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfCannotChangeStatus(bool when,
        Enum newStatus,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("when")] string?  wheneName = null,
        [CallerArgumentExpression("newStatus")] string?  newStatusName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (when)
        {
            //var exception = Create($"When '{wheneName}' you cannot change status of {objectName} on '{newStatusName}'", message);
            //if (exception != null) 
            //{ 
            //    throw exception; 
            //}
        }
    }
}