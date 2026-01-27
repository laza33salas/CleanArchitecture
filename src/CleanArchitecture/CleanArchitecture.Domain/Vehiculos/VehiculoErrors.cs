using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos;

public static class VehiculoErrors
{
    public static readonly Error NotFound = new(
        "Vehiculo.NotFound",
        "Vehículo no encontrado");
}