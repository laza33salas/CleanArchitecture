using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using Dapper;

namespace CleanArchitecture.Application.Alquileres.GetAlquiler;

internal sealed class GetAlquilerQueryHandler : IQueryHandler<GetAlquilerQuery, AlquilerResponse>
{

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAlquilerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<AlquilerResponse>> Handle(
        GetAlquilerQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """ 
        SELECT 
        id AS Id,
        vechiculo_id AS VehiculoId,
        user_id AS UserId,
        status AS Status,
        precio_por_periodo AS PrecioAlquiler,
        precio_por_periodo_moneda AS TipoMonedaAlquiler,
        precio_mantenimiento AS PrecioMantenimiento,
        precio_mantenimiento_moneda AS TipoMonedaMantenimiento,
        precio_accesorio AS AccesorioPrecio,
        precio_accesorio_moneda AS TipoMonedaAccesorio,
        precio_total AS PrecioTotal,
        precio_total_moneda AS TipoMonedaTotal,
        duracion_inicio AS DuracionInicio,
        duracion_fin AS DuracionFin,
        fecha_creacion AS FechaCreacion
        
        FROM alquileres WHERE id=@AlquilerId
        """;
        var alquiler = await connection.QueryFirstOrDefaultAsync<AlquilerResponse>(
            sql,
            new
            {
                request.AlquilerId
            }
        );

        return alquiler!;
    }
}