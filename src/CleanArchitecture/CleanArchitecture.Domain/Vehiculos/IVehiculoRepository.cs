namespace CleanArchitecture.Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task AddAsync(Vehiculo vehiculo, CancellationToken cancellationToken = default);
    Task<Vehiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}