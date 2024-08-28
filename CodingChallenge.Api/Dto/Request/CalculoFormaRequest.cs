using CodingChallenge.Domain.Enums;

namespace CodingChallenge.Api.Dto.Request;

/// <summary>
/// Representa una solicitud para calcular propiedades de una forma geométrica.
/// </summary>
public class CalculoFormaRequest
{
    /// <summary>
    /// El tipo de forma geométrica. Puede ser Circulo, Cuadrado, Rectangulo, Trapecio o TrianguloEquilatero.
    /// </summary>
    public TipoForma TipoForma { get; set; }

    /// <summary>
    /// El primer parámetro necesario para la forma (e.g., radio para el círculo, lado para el cuadrado, largo para el rectangulo, base mayor para el Trapecio).
    /// </summary>
    public decimal Parametro1 { get; set; }

    /// <summary>
    /// Parámetro opcional dependiendo del tipo de forma (e.g., ancho para el rectángulo, base menor para el trapecia).
    /// </summary>
    public decimal? Parametro2 { get; set; }

    /// <summary>
    /// Parámetro opcional adicional dependiendo del tipo de forma (ejm, Lado 1 para el trapecio).
    /// </summary>
    public decimal? Parametro3 { get; set; }

    /// <summary>
    /// Parámetro opcional adicional dependiendo del tipo de forma (ejm, Lado 2 para el trapecio).
    /// </summary>
    public decimal? Parametro4 { get; set; }

    /// <summary>
    /// Parámetro opcional adicional dependiendo del tipo de forma (ejm, Lado Altura para el trapecio).
    /// </summary>
    public decimal? Parametro5 { get; set; }
}