using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Domain.Entities;

public class TrianguloEquilatero : FormaGeometrica
{
    public decimal Lado { get; set; }

    public TrianguloEquilatero(decimal lado)
    {
        if (lado <= 0)
            throw new ArgumentException("El lado debe ser un número positivo.");

        Lado = lado;
    }

    public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
    public override decimal CalcularPerimetro() => Lado * 3;
}