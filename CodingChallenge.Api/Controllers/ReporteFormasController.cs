using System.Text.Json;
using CodingChallenge.Api.Controllers.Common;
using CodingChallenge.Api.Dto.Request;
using CodingChallenge.Api.Dto.Response;
using CodingChallenge.Services.Factory;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Api.Controllers;

public class ReporteFormasController : BaseApiController
{
    private readonly ILogger<ReporteFormasController> _logger;
    private readonly IFormaGeometricaFactory _formaGeometricaFactory;

    public ReporteFormasController(
        ILogger<ReporteFormasController> logger,
        IFormaGeometricaFactory formaGeometricaFactory)
    {
        _logger = logger;
        _formaGeometricaFactory = formaGeometricaFactory;
    }
    
    [HttpGet("calcular")]
    public IActionResult Calcular([FromQuery] CalculoFormaRequest calculoFormaRequest)
    {
        _logger.LogInformation("CalcularPerimetro: {calculoFormaRequest}", JsonSerializer.Serialize(calculoFormaRequest));
        
        var forma = _formaGeometricaFactory.CrearForma(calculoFormaRequest.TipoForma, calculoFormaRequest.Parametro1, calculoFormaRequest.Parametro2, calculoFormaRequest.Parametro3, calculoFormaRequest.Parametro4, calculoFormaRequest.Parametro5);

        var result = new CalculoFormaResponse(calculoFormaRequest.TipoForma.ToString(), forma.CalcularArea(), forma.CalcularPerimetro());
        
        _logger.LogInformation("CalcularPerimetro - Result: {result}", JsonSerializer.Serialize(result));
            
        return Ok(result);
    }
}