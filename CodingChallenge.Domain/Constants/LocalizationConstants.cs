namespace CodingChallenge.Domain.Constants;

public static class LocalizationConstants
{
    public static readonly LenguajeCodigo[] LenguajesSoportados =
    {
        new()
        {
            Codigo = "es",
            Nombre = "Español"
        },
        new()
        {
            Codigo = "en",
            Nombre = "Ingles"
        }
    };
}

public class LenguajeCodigo
{
    public string Nombre { get; set; } = "en";
    public string Codigo { get; set; } = "Ingles";
}