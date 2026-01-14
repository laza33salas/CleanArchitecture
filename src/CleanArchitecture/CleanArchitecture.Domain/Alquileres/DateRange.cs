namespace CleanArchitecture.Domain.Alquileres;

public sealed record DateRange
{
    private DateRange()
    {

    }

    public DateOnly Inicio { get; init; }
    public DateOnly Fin { get; init; }

    public int CantidadDias => Fin.DayNumber - Inicio.DayNumber;
    public static DateRange Create(DateOnly inicio, DateOnly fin)
    {
        if (fin <= inicio)
        {
            throw new ArgumentException("La fecha de fin debe ser mayor a la fecha de inicio.");
        }

        return new DateRange
        {
            Inicio = inicio,
            Fin = fin
        };
    }
}