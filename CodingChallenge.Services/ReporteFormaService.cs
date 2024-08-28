using System.Globalization;
using System.Text;
using CodingChallenge.Domain.Entities.Common;
using Microsoft.Extensions.Localization;

namespace CodingChallenge.Services;

public class ReporteFormaService : IReporteFormaService
{
    private readonly IStringLocalizer<ReporteFormaService> _localizer;

    public ReporteFormaService(IStringLocalizer<ReporteFormaService> localizer)
    {
        _localizer = localizer;
    }

    public string Imprimir(List<FormaGeometrica> formas, string idioma)
    {
        var cultura = new CultureInfo(idioma);
        
        Thread.CurrentThread.CurrentUICulture = cultura;
        
        var sb = new StringBuilder();

        if (!formas.Any())
        {
            var listaVacia = _localizer["ListaVacia"];
            sb.Append(listaVacia);

            return sb.ToString();
        }

        sb.Append(_localizer["ReporteEncabezado"]);

        var resumen = formas.GroupBy(f => f.GetType())
            .Select(g => new
            {
                Tipo = g.First(),
                Cantidad = g.Count(),
                Area = g.Sum(f => f.CalcularArea()),
                Perimetro = g.Sum(f => f.CalcularPerimetro())
            });

        foreach (var item in resumen)
        {
            string nombreForma = _localizer[$"{item.Tipo.GetType().Name}_{(item.Cantidad == 1 ? "Singular" : "Plural")}"];
            
            sb.Append($"{item.Cantidad} {nombreForma} | {_localizer["Area"]} {item.Area.ToString("#.##", CultureInfo.InvariantCulture)} | {_localizer["Perimetro"]} {item.Perimetro.ToString("#.##", CultureInfo.InvariantCulture)} <br/>");
        }

        sb.Append($"{_localizer["Total"]}:<br/>{formas.Count} {_localizer["Formas"]} | {_localizer["Perimetro"]} {formas.Sum(f => f.CalcularPerimetro()).ToString("#.##", CultureInfo.InvariantCulture)} | {_localizer["Area"]} {formas.Sum(f => f.CalcularArea()).ToString("#.##", CultureInfo.InvariantCulture)}");

        return sb.ToString();
    }
}