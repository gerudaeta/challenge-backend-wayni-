using CodingChallenge.Domain.Enums;
using FluentValidation;

namespace CodingChallenge.Api.Dto.Request;

public class CalculoFormaRequestValidator : AbstractValidator<CalculoFormaRequest>
{
    public CalculoFormaRequestValidator()
    {
         RuleFor(x => x.TipoForma)
            .IsInEnum().WithMessage("El tipo de forma es inválido.");

        // Validación para Circulo
        When(x => x.TipoForma == TipoForma.Circulo, () =>
        {
            RuleFor(x => x.Parametro1)
                .GreaterThan(0).WithMessage("El radio debe ser mayor que cero.")
                .WithName("Radio");
        });

        // Validación para Cuadrado
        When(x => x.TipoForma == TipoForma.Cuadrado, () =>
        {
            RuleFor(x => x.Parametro1)
                .GreaterThan(0).WithMessage("El lado debe ser mayor que cero.")
                .WithName("Lado");
        });

        // Validación para Rectangulo
        When(x => x.TipoForma == TipoForma.Rectangulo, () =>
        {
            RuleFor(x => x.Parametro1)
                .GreaterThan(0).WithMessage("La longitud debe ser mayor que cero.")
                .WithName("Longitud");
            
            RuleFor(x => x.Parametro2)
                .NotNull().WithMessage("El ancho es requerido.")
                .GreaterThan(0).WithMessage("El ancho debe ser mayor que cero.")
                .WithName("Ancho");
        });

        // Validación para Trapecio
        When(x => x.TipoForma == TipoForma.Trapecio, () =>
        {
            RuleFor(x => x.Parametro1)
                .GreaterThan(0).WithMessage("La base mayor debe ser mayor que cero.")
                .WithName("BaseMayor");

            RuleFor(x => x.Parametro2)
                .NotNull().WithMessage("La base menor es requerida.")
                .GreaterThan(0).WithMessage("La base menor debe ser mayor que cero.")
                .WithName("BaseMenor");

            RuleFor(x => x.Parametro3)
                .NotNull().WithMessage("La altura es requerida.")
                .GreaterThan(0).WithMessage("La altura debe ser mayor que cero.")
                .WithName("Altura");

            RuleFor(x => x.Parametro4)
                .NotNull().WithMessage("El lado 1 es requerido.")
                .GreaterThan(0).WithMessage("El lado 1 debe ser mayor que cero.")
                .WithName("Lado1");

            RuleFor(x => x.Parametro5)
                .NotNull().WithMessage("El lado 2 es requerido.")
                .GreaterThan(0).WithMessage("El lado 2 debe ser mayor que cero.")
                .WithName("Lado2");
        });

        // Validación para Triangulo Equilatero
        When(x => x.TipoForma == TipoForma.TrianguloEquilatero, () =>
        {
            RuleFor(x => x.Parametro1)
                .GreaterThan(0).WithMessage("El lado debe ser mayor que cero.")
                .WithName("Lado");
        });
    }
}