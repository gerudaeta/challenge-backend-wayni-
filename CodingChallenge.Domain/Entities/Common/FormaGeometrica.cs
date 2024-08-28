namespace CodingChallenge.Domain.Entities.Common;

public abstract class FormaGeometrica: ICalculableArea, ICalculablePerimetro
{
    public abstract decimal CalcularArea();
    public abstract decimal CalcularPerimetro();
}