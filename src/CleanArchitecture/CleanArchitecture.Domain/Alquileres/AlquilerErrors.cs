using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres;

public static class AlquilerErrors
{
    public static Error NotFound = new Error(
     "Alquiler.NotFound",
     "El alquiler con el id especificado no fue encontrado."
    );

    public static Error Overlap = new Error(
     "Alquiler.Overlap",
     "El alquiler se superpone con otro alquiler existente."
    );

    public static Error NotReserved = new Error(
     "Alquiler.NotReserved",
     "El alquiler no está en estado reservado."
    );

    public static Error NotConfirmed = new Error(
     "Alquiler.NotConfirmed",
     "El alquiler no está en estado confirmado."
    );

    public static Error AlReadyStarted = new Error(
     "Alquiler.AlReadyStarted",
     "El alquiler ya ha comenzado."
    );
}