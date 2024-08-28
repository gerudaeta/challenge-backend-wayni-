namespace CodingChallenge.Api.Dto.Response;

/// <summary>
/// 
/// </summary>
/// <param name="TipoForma">Tipo de Forma</param>
/// <param name="Area">Resultado del Area calculada</param>
/// <param name="Perimetro">Resultado del Perimetro calculado</param>
public record CalculoFormaResponse(string TipoForma, decimal Area, decimal Perimetro);