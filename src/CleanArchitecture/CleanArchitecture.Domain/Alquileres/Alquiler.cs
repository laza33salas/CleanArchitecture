using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres;

public sealed class Alquiler : Entity
{
    public Alquiler(Guid id) : base(id)
    {
    }

    public AlquilerStatus Status { get; private set; }
}