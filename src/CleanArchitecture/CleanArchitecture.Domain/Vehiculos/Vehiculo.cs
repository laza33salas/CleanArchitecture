namespace CleanArchitecture.Domain.Vehiculos;

public sealed class Vehiculos
{
   public Guid Id { get; private set; }
   public string? Modelo { get; private set; }
   public string? Vin { get; private set; } //Número de serie
   public string? Calle { get; private set; }
   public string? Departamento { get; private set; }
   public string? Ciudad { get; private set; }
   public string? Pais { get; private set; }
   public decimal Precio { get; private set; }
   public string? TipoMoneda { get; private set; }
   public decimal Mantenimiento { get; private set; }
   public string? MantenimientoTipoMoneda { get; private set; }
   public DateTime? FechaUltimoAlquiler { get; private set; }

}