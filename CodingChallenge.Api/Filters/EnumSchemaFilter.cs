using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CodingChallenge.Api.Filters;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum) return;
        
        schema.Enum = Enum.GetNames(context.Type).Select(name => new OpenApiString(name)).ToList<IOpenApiAny>();
        schema.Type = "string";
        schema.Format = null;
    }
}