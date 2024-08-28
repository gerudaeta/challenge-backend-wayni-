using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Domain.Entities;

public class Rectangulo : FormaGeometrica
{
    public decimal Base { get; set; }
    public decimal Altura { get; set; }

    public Rectangulo(decimal baseRectangulo, decimal altura)
    {
        if (baseRectangulo <= 0)
            throw new ArgumentException("La base debe ser un número positivo.");

        if (altura <= 0)
            throw new ArgumentException("La altura debe ser un número positivo.");

        Base = baseRectangulo;
        Altura = altura;
    }

    public override decimal CalcularArea() => Base * Altura;
    public override decimal CalcularPerimetro() => 2 * (Base + Altura);
}