namespace MicroservicesFramework.DesingByContract;

public static class ExceptionFactory<TException> where TException : Exception
{
    public static TException Create<T>(string partDefaultMessage,
        string objectName,
        string? customMessage = null,
        object? id = null,
        string? valueName = null,
        string? idName = null)
    {
        if (string.IsNullOrWhiteSpace(partDefaultMessage))
        {
            throw new ApplicationException("No passed default exception message.");
        }

        var entityWithId = (object? id) => id is not null && !string.IsNullOrWhiteSpace(id.ToString())
            ? $"'{objectName}' with {GetIdDescription(id, idName)}"
            : $"'{objectName}'";

        var entityDescription = !string.IsNullOrWhiteSpace(objectName) 
            ? $" in {entityWithId(id)}"
            : string.Empty;

        var valueDescription = GetValueDescription<T>(valueName);
        var defaultMessage = $"{valueDescription}{entityDescription} {partDefaultMessage}.";

        var message = customMessage ?? defaultMessage;

        var exception = (TException?)Activator.CreateInstance(typeof(TException), new object[] { message });

        return exception ?? throw new ApplicationException("Cannot create exception");
    }

    private static string GetIdDescription(object? id, string? idName)
    {
        var idLabel = string.IsNullOrWhiteSpace(idName) 
            ? "ID" 
            : idName;

        return $"'{idLabel}: {id}'";
    }

    private static string GetValueDescription<T>(string? valueName)
    {
        var valueLabel = string.IsNullOrWhiteSpace(valueName) 
            ? $"{typeof(T).Name} value"
            : $"'{valueName}'";

        return $"{valueLabel}";
    }
}