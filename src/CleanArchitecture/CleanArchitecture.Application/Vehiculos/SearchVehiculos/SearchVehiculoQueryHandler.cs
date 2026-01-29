using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;
using Dapper;

namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos;

internal sealed class SearchVehiculoQueryHandler
: IQueryHandler<SearchVehiculosQuery, IReadOnlyList<VehiculoResponse>>
{
    private static readonly int[] ActiveAlquilerStatuses =
    {
        (int)AlquilerStatus.Reservado,
        (int)AlquilerStatus.Confirmado,
        (int)AlquilerStatus.Completado
    };
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchVehiculoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(
        SearchVehiculosQuery request,
        CancellationToken cancellationToken)
    {
        if (request.FechaInicio >= request.FechaFin)
        {
            return new List<VehiculoResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """ 
        
        SELECT
            a.id AS Id,
            a.modelo AS Modelo,
            a.vin AS Vin,
            a.precio AS Precio,
            a.precio_moneda AS TipoMoneda,
            a.direccion_pais AS Pais,
            a.direccion_ciudad AS Ciudad,
            a.direccion_provincia AS Provincia,
            a.direccion_calle AS Calle
        FROM vehiculos AS a
        WHERE NOT EXISTS
        (
        
        SELECT 1 
        FROM alquileres AS b
        WHERE 
             b.vechiculo_id = a.id
             b.duracion_inicio <= @EndDate AND 
             b.durracion_final >= @StarDate AND
             b.status = ANY(@ActiveAlquilerStatuses)
        """;


        var vehiculos = await connection
        .QueryAsync<VehiculoResponse, DireccionResponse, VehiculoResponse>
        (
            sql,
            (vehiculo, direccion) =>
            {
                vehiculo.Direccion = direccion;
                return vehiculo;
            },
            new
            {
                StartDate = request.FechaInicio,
                EndDate = request.FechaFin,
                ActiveAlquilerStatuses
            },

            splitOn: "Pais"
        );

        return vehiculos.ToList();
    }
}