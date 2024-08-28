using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Domain.Enums;

public enum TipoForma
{
    [Display(Name = "Circulo")]
    Circulo = 1,
    [Display(Name = "Cuadrado")]
    Cuadrado = 2,
    [Display(Name = "Rectángulo")]
    Rectangulo = 3,
    [Display(Name = "Trapecio")]
    Trapecio = 4,
    [Display(Name = "Triángulo Equilátero")]
    TrianguloEquilatero = 5
}