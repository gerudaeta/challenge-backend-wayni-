using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Domain.Entities;

public class Trapecio : FormaGeometrica
{
    public decimal BaseMayor { get; set; }

    public decimal BaseMenor { get; set; }

    public decimal Lado1 { get; set; }

    public decimal Lado2 { get; set; }

    public decimal Altura { get; set; }

    public Trapecio(decimal baseMayor, decimal baseMenor, decimal lado1, decimal lado2, decimal altura)
    {
        if (baseMayor <= 0 || baseMenor <= 0 || lado1 <= 0 || lado2 <= 0 || altura <= 0)
            throw new ArgumentException("Todas las dimensiones deben ser positivas.");

        if (baseMayor <= baseMenor)
            throw new ArgumentException("La base mayor debe ser mayor que la base menor.");

        BaseMayor = baseMayor;
        BaseMenor = baseMenor;
        Lado1 = lado1;
        Lado2 = lado2;
        Altura = altura;
    }

    public override decimal CalcularArea() => (BaseMayor + BaseMenor) / 2 * Altura;
    public override decimal CalcularPerimetro() => BaseMayor + BaseMenor + Lado1 + Lado2;
}