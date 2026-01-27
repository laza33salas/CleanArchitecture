using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Alquileres.Events;
using CleanArchitecture.Domain.Users;
using MediatR;

namespace CleanArchitecture.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerDomainEventHandler
: INotificationHandler<AlquilerReservadoDomainEvent>
{

    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService emailService;

    public ReservarAlquilerDomainEventHandler(
        IAlquilerRepository alquilerRepository,
         IUserRepository userRepository,
          IEmailService emailService)
    {
        this._alquilerRepository = alquilerRepository;
        this._userRepository = userRepository;
        this.emailService = emailService;
    }

    public Task Handle(
        AlquilerReservadoDomainEvent notification,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}