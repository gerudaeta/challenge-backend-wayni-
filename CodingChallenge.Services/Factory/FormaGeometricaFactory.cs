using CodingChallenge.Domain.Entities;
using CodingChallenge.Domain.Entities.Common;
using CodingChallenge.Domain.Enums;

namespace CodingChallenge.Services.Factory;

public class FormaGeometricaFactory : IFormaGeometricaFactory
{
    public FormaGeometrica CrearForma(TipoForma tipoForma, decimal parametro1, decimal? parametro2 = null, decimal? parametro3 = null, decimal? parametro4 = null, decimal? parametro5 = null)
    {
        return tipoForma switch
        {
            TipoForma.Circulo => new Circulo(parametro1),
            TipoForma.Cuadrado => new Cuadrado(parametro1),
            TipoForma.Rectangulo => new Rectangulo(parametro1, parametro2!.Value),
            TipoForma.Trapecio => new Trapecio(parametro1, parametro2.Value, parametro3.Value, parametro4.Value, parametro5.Value),
            TipoForma.TrianguloEquilatero => new TrianguloEquilatero(parametro1),
            _ => throw new ArgumentOutOfRangeException("Forma desconocida, ingrese una forma correcta")
        };
    }
}