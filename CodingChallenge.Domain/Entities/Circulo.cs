using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Domain.Entities;

public class Circulo : FormaGeometrica
{
    public decimal Radio { get; set; }

    public Circulo(decimal radio)
    {
        if (radio <= 0)
            throw new ArgumentException("El radio debe ser un número positivo.");

        Radio = radio;
    }

    public override decimal CalcularArea() => (decimal)Math.PI * (Radio / 2) * (Radio / 2);
    public override decimal CalcularPerimetro() => (decimal)Math.PI * Radio;
    
}