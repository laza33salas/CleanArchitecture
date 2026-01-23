using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerCommandHandler
: ICommandHandler<ReservarAlquilerCommand, Guid>
{


    public Task<Result<Guid>> Handle(
    ReservarAlquilerCommand request,
    CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}