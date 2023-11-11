using System.Runtime.CompilerServices;

namespace MicroFusion.DesingByContract;

public abstract partial class Exception<TException, TObject> : Exception
    where TException : Exception
    where TObject : class
{
    public static void ThrowIfCannotChange(bool when,
        Enum newStatus,
        object? id = null,
        string? message = null,
        [CallerArgumentExpression("when")] string?  wheneName = null,
        [CallerArgumentExpression("newStatus")] string?  newStatusName = null,
        [CallerArgumentExpression("id")] string? idName = null)
    {
        if (newStatus is null)
        {
            throw new ArgumentException(nameof(wheneName));
        }

        if (newStatusName is null)
        {
            throw new ArgumentException(nameof(wheneName));
        }

        if (wheneName is null)
        {
            throw new ArgumentException(nameof(newStatusName));
        }

        if (when)
        {
            var idDescription = $" with {idName ?? "ID"}:{id}";
            var objectDescription = !string.IsNullOrWhiteSpace(objectName) 
                && !string.IsNullOrWhiteSpace(id?.ToString()) 
                && !string.IsNullOrWhiteSpace(idName) 
                    ?  $" in '{objectName}{idDescription}'"
                    : string.Empty;

            var defaultMessage = $"When '{wheneName}' then you cannot change state to '{newStatusName}'{objectDescription}.";
            var selectedMessage = message ?? defaultMessage;

            var exception = (TException?)Activator.CreateInstance(typeof(TException), new object[] { selectedMessage });

            if (exception != null) 
            { 
                throw exception ?? throw new ApplicationException("Cannot create exception");
            }
        }
    }
}