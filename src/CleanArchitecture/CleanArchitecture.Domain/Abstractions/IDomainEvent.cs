using MediatR;

namespace CleanArchitecture.Domain.Abstractions;

public interface IDomainEvent : INotification // de MediatR
{
    //publisher -> se encarga de enviar los eventos
    //subscriber -> agente que esta escuchando los mensajes que envia publisher y captura lo eventos a futuro


}