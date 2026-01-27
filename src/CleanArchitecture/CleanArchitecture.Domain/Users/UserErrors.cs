using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.NotFound",
        "Usuario no encontrado");

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Credenciales inválidas");
}