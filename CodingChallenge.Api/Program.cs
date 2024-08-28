using System.Reflection;
using CodingChallenge.Api.Filters;
using CodingChallenge.Api.Middleware;
using CodingChallenge.Domain.Constants;
using CodingChallenge.Services;
using CodingChallenge.Services.Factory;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddProblemDetails();

builder.Services.AddLocalization();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Obtén la ruta del archivo de documentación XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Incluir comentarios XML
    c.IncludeXmlComments(xmlPath);
    
    c.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddTransient<IReporteFormaService, ReporteFormaService>();
builder.Services.AddTransient<IFormaGeometricaFactory, FormaGeometricaFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(LocalizationConstants.LenguajesSoportados.Select(x => x.Codigo).First())
    .AddSupportedCultures(LocalizationConstants.LenguajesSoportados.Select(x => x.Codigo).ToArray())
    .AddSupportedUICultures(LocalizationConstants.LenguajesSoportados.Select(x => x.Codigo).ToArray());

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();