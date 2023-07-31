using ControlServices.Core.Models.Enuns;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ControlServices.Infra.IoC.SwaggerFilters;
public class AcceptLanguageHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Insert(0, new OpenApiParameter
        {
            In = ParameterLocation.Header,
            Name = "accept-language",
            // Description = "pass the locale here: examples like => pt,en",
            Schema = new OpenApiSchema
            {
                Type = "string",
                Default = new OpenApiString(Culture.Portugues.GetDisplayName()),
                Enum = typeof(Culture).GetEnumNames().Select(name => new OpenApiString(name)).Cast<IOpenApiAny>().ToList(),
                Nullable = true
            },
            //Required = true
        });
    }
}
