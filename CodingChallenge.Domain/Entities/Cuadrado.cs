using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Domain.Entities;

public class Cuadrado : FormaGeometrica
{
    public decimal Lado { get; set; }

    public Cuadrado(decimal lado)
    {
        if (lado <= 0)
            throw new ArgumentException("El lado debe ser un número positivo.");
        
        Lado = lado;
    }
    
    public override decimal CalcularArea() => Lado * Lado;
    public override decimal CalcularPerimetro() => Lado * 4;
}