using CodingChallenge.Domain.Entities;
using CodingChallenge.Domain.Enums;
using CodingChallenge.Services.Factory;

namespace CodingChallenge.Services.Tests;

[TestFixture]
public class FormaGeometricaFactoryTests
{
    private FormaGeometricaFactory _formaGeometricaFactory;

    [SetUp]
    public void Setup()
    {
        _formaGeometricaFactory = new FormaGeometricaFactory();
    }

    [Test]
    public void CrearForma_CuandoTipoEsCirculo_DeberiaRetornarCirculo()
    {
        // Arrange
        const decimal radio = 5m;

        // Act
        var resultado = _formaGeometricaFactory.CrearForma(TipoForma.Circulo, radio);

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(resultado, Is.InstanceOf<Circulo>());
            Assert.That(((Circulo)resultado).Radio, Is.EqualTo(radio));
        });
    }

    [Test]
    public void CrearForma_CuandoTipoEsCuadrado_DeberiaRetornarCuadrado()
    {
        // Arrange
        const decimal lado = 4m;

        // Act
        var resultado = _formaGeometricaFactory.CrearForma(TipoForma.Cuadrado, lado);

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(resultado, Is.InstanceOf<Cuadrado>());
            Assert.That(((Cuadrado)resultado).Lado, Is.EqualTo(lado));
        });
    }

    [Test]
    public void CrearForma_CuandoTipoEsRectangulo_DeberiaRetornarRectangulo()
    {
        // Arrange
        const decimal ancho = 4m;
        const decimal alto = 6m;

        // Act
        var resultado = _formaGeometricaFactory.CrearForma(TipoForma.Rectangulo, ancho, alto);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultado, Is.InstanceOf<Rectangulo>());
            Assert.That(((Rectangulo)resultado).Base, Is.EqualTo(ancho));
            Assert.That(((Rectangulo)resultado).Altura, Is.EqualTo(alto));
        });
    }

    [Test]
    public void CrearForma_CuandoTipoEsTrapecio_DeberiaRetornarTrapecio()
    {
        // Arrange
        const decimal baseMayor = 8m;
        const decimal baseMenor = 6m;
        const decimal altura = 5m;
        const decimal lado1 = 7m;
        const decimal lado2 = 7m;

        // Act
        var resultado = _formaGeometricaFactory.CrearForma(TipoForma.Trapecio, baseMayor, baseMenor, lado1, lado2, altura);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultado, Is.InstanceOf<Trapecio>());
            Assert.That(((Trapecio)resultado).BaseMayor, Is.EqualTo(baseMayor));
            Assert.That(((Trapecio)resultado).BaseMenor, Is.EqualTo(baseMenor));
            Assert.That(((Trapecio)resultado).Lado1, Is.EqualTo(lado1));
            Assert.That(((Trapecio)resultado).Lado2, Is.EqualTo(lado2));
            Assert.That(((Trapecio)resultado).Altura, Is.EqualTo(altura));
        });
    }

    [Test]
    public void CrearForma_CuandoTipoEsTrianguloEquilatero_DeberiaRetornarTrianguloEquilatero()
    {
        // Arrange
        const decimal lado = 3m;

        // Act
        var resultado = _formaGeometricaFactory.CrearForma(TipoForma.TrianguloEquilatero, lado);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultado, Is.InstanceOf<TrianguloEquilatero>());
            Assert.That(((TrianguloEquilatero)resultado).Lado, Is.EqualTo(lado));
        });
    }
}