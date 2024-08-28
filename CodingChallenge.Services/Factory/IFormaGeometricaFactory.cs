using CodingChallenge.Domain.Entities.Common;
using CodingChallenge.Domain.Enums;

namespace CodingChallenge.Services.Factory;

public interface IFormaGeometricaFactory
{
    FormaGeometrica CrearForma(TipoForma tipoForma, decimal parametro1, decimal? parametro2 = null, decimal? parametro3 = null, decimal? parametro4 = null, decimal? parametro5 = null);
}