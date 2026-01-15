namespace CleanArchitecture.Domain.Alquileres;

public static class AlquilerErrors
{
    public static Error NotFound = new Error(
     "Alquiler.NotFound",
     "El alquiler con el id especificado no fue encontrado."
    )
}