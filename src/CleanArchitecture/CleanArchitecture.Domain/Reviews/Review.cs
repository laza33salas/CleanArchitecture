using System.Reflection.Metadata.Ecma335;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Reviews.Events;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Reviews;

public sealed class Review : Entity
{

    private Review(
        Guid id,
        Guid vehiculoId,
        Guid alquilerId,
        Guid userId,
        Rating rating,
        Review comentario,
        DateTime fechaCreacion
        ) : base(id)
    {
        VehiculoId = vehiculoId;
        AlquilerId = alquilerId;
        UserId = userId;
        Rating = rating;
        Comentario = comentario;
        FechaCreacion = fechaCreacion;
    }

    public Guid VehiculoId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid AlquilerId { get; private set; }
    public Rating Rating { get; private set; }
    public Review Comentario { get; private set; }
    public DateTime FechaCreacion { get; private set; }


    public static Result<Review> Create(
       Alquiler alquiler,
       Rating rating,
       Review comentario,
       DateTime fechaCreacion
        )
    {
        if (alquiler.Status != AlquilerStatus.Completado)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }

        var review = new Review(
            Guid.NewGuid(),
            alquiler.VehiculoId,
            alquiler.Id,
            alquiler.UserId,
            rating,
            comentario,
            fechaCreacion
            );


        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));
        return review;
    }

}