using CodingChallenge.Domain.Entities.Common;

namespace CodingChallenge.Services;

public interface IReporteFormaService
{
    string Imprimir(List<FormaGeometrica> formas, string idioma);
}