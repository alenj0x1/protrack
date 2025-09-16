namespace Protrack.Shared.Constants;

public static class ResponseConstants
{
    // Default
    public const string DefaultResponse = "Solicitud procesada correctamente";
    
    // Exceptions
    public static string MissingArgument(string argumentName) => $"Debe proporcionar el siguiente argumento: {argumentName}";
    
    // Services
    // User
    public const string UserCreatedCorrectly = "Usuario creado correctamente";
}