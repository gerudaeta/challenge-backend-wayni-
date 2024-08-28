using CodingChallenge.Domain.Entities;
using CodingChallenge.Domain.Entities.Common;
using Microsoft.Extensions.Localization;
using Moq;

namespace CodingChallenge.Services.Tests;

[TestFixture]
public class ReporteFormaServiceTests
{
    private readonly Mock<IStringLocalizer<ReporteFormaService>> _mockLocalizer;
    private readonly ReporteFormaService _reporteFormaService;

    public ReporteFormaServiceTests()
    {
        _mockLocalizer = new Mock<IStringLocalizer<ReporteFormaService>>();
        _reporteFormaService = new ReporteFormaService(_mockLocalizer.Object);
    }
    
    [Test]
    public void TestResumenListaVacia()
    {
        // Arrange
        var formas = new List<FormaGeometrica>();
        
        _mockLocalizer.Setup(l => l["ListaVacia"]).Returns(new LocalizedString("ListaVacia", "<h1>Lista vacía de formas!</h1>"));

        // Act
        var resultado = _reporteFormaService.Imprimir(formas, "es");

        // Assert
        Assert.That(resultado, Is.EqualTo("<h1>Lista vacía de formas!</h1>"));
    }
    
    [Test]
    public void TestResumenListaVaciaFormasEnIngles()
    {
        // Arrange
        var formas = new List<FormaGeometrica>();
        
        _mockLocalizer.Setup(l => l["ListaVacia"]).Returns(new LocalizedString("ListaVacia", "<h1>Empty list of shapes!</h1>"));
        
        // Act
        var resultado = _reporteFormaService.Imprimir(formas, "en");

        // Assert
        Assert.That(resultado, Is.EqualTo("<h1>Empty list of shapes!</h1>"));
    }
    
    [Test]
    public void TestResumenListaConUnCuadrado()
    {
        // Arrange
        var cuadrados = new List<FormaGeometrica>
        {
            new Cuadrado(5)
        };
        
        _mockLocalizer.Setup(l => l["ReporteEncabezado"]).Returns(new LocalizedString("ReporteEncabezado", "<h1>Reporte de Formas</h1>"));
        
        _mockLocalizer.Setup(l => l["Cuadrado_Singular"]).Returns(new LocalizedString("Cuadrado_Singular", "Cuadrado"));
        
        _mockLocalizer.Setup(l => l["Perimetro"]).Returns(new LocalizedString("Perimetro", "Perimetro"));
        
        _mockLocalizer.Setup(l => l["Area"]).Returns(new LocalizedString("Area", "Area"));
        
        _mockLocalizer.Setup(l => l["Total"]).Returns(new LocalizedString("Total", "TOTAL"));
        
        _mockLocalizer.Setup(l => l["Formas"]).Returns(new LocalizedString("Formas", "formas"));

        // Act
        var resumen = _reporteFormaService.Imprimir(cuadrados, "es");

        // Assert
        Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas | Perimetro 20 | Area 25"));
    }
    
    [Test]
    public void TestResumenListaConMasCuadrados()
    {
        // Arrange
        var cuadrados = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Cuadrado(1),
            new Cuadrado(3)
        };
        
        _mockLocalizer.Setup(l => l["ReporteEncabezado"]).Returns(new LocalizedString("ReporteEncabezado", "<h1>Shapes report</h1>"));
        
        _mockLocalizer.Setup(l => l["Cuadrado_Plural"]).Returns(new LocalizedString("Cuadrado_Plural", "Squares"));
        
        _mockLocalizer.Setup(l => l["Area"]).Returns(new LocalizedString("Area", "Area"));
        
        _mockLocalizer.Setup(l => l["Perimetro"]).Returns(new LocalizedString("Perimetro", "Perimeter"));
        
        _mockLocalizer.Setup(l => l["Total"]).Returns(new LocalizedString("Total", "TOTAL"));
        
        _mockLocalizer.Setup(l => l["Formas"]).Returns(new LocalizedString("Formas", "shapes"));

        // Act
        var resumen = _reporteFormaService.Imprimir(cuadrados, "en");

        // Assert
        Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes | Perimeter 36 | Area 35"));
    }

    [Test]
    public void TestResumenListaConMasTipos()
    {
        // Arrange
        var formas = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        
        _mockLocalizer.Setup(l => l["ReporteEncabezado"]).Returns(new LocalizedString("ReporteEncabezado", "<h1>Shapes report</h1>"));
        
        _mockLocalizer.Setup(l => l["Cuadrado_Plural"]).Returns(new LocalizedString("Cuadrado_Plural", "Squares"));
        
        _mockLocalizer.Setup(l => l["Circulo_Plural"]).Returns(new LocalizedString("Circulo_Plural", "Circles"));
        
        _mockLocalizer.Setup(l => l["TrianguloEquilatero_Plural"]).Returns(new LocalizedString("TrianguloEquilatero_Plural", "Triangles"));
        
        _mockLocalizer.Setup(l => l["Area"]).Returns(new LocalizedString("Area", "Area"));
        
        _mockLocalizer.Setup(l => l["Perimetro"]).Returns(new LocalizedString("Perimetro", "Perimeter"));
        
        _mockLocalizer.Setup(l => l["Total"]).Returns(new LocalizedString("Total", "TOTAL"));
        
        _mockLocalizer.Setup(l => l["Formas"]).Returns(new LocalizedString("Formas", "shapes"));

        // Act
        var resumen = _reporteFormaService.Imprimir(formas, "en");

        // Assert
        Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes | Perimeter 97.66 | Area 91.65"));
    }

    [Test]
    public void TestResumenListaConMasTiposEnCastellano()
    {
        // Arrange
        var formas = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        
        _mockLocalizer.Setup(l => l["ReporteEncabezado"]).Returns(new LocalizedString("ReporteEncabezado", "<h1>Reporte de Formas</h1>"));
        
        _mockLocalizer.Setup(l => l["Cuadrado_Plural"]).Returns(new LocalizedString("Cuadrado_Plural", "Cuadrados"));
        
        _mockLocalizer.Setup(l => l["Circulo_Plural"]).Returns(new LocalizedString("Circulo_Plural", "Círculos"));
        
        _mockLocalizer.Setup(l => l["Perimetro"]).Returns(new LocalizedString("Perimetro", "Perimetro"));
        
        _mockLocalizer.Setup(l => l["Area"]).Returns(new LocalizedString("Area", "Area"));
        
        _mockLocalizer.Setup(l => l["Total"]).Returns(new LocalizedString("Total", "TOTAL"));
        
        _mockLocalizer.Setup(l => l["Formas"]).Returns(new LocalizedString("Formas", "formas"));
        
        _mockLocalizer.Setup(l => l["TrianguloEquilatero_Plural"]).Returns(new LocalizedString("TrianguloEquilatero_Plural", "Triángulos"));

        // Act
        var resumen = _reporteFormaService.Imprimir(formas, "es");

        // Assert
        Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13.01 | Perimetro 18.06 <br/>3 Triángulos | Area 49.64 | Perimetro 51.6 <br/>TOTAL:<br/>7 formas | Perimetro 97.66 | Area 91.65"));
    }
}