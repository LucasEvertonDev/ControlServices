using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ControlServices.Infra.IoC.SwaggerConfig;
public class AcceptLanguageHeaderFilter : IOperationFilter
{
    public void Apply(Microsoft.OpenApi.Models.OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Add(new OpenApiParameter
        {
            In = ParameterLocation.Header,
            Name = "accept-language",
            Description = "pass the locale here: examples like => pt,en",
            Schema = new OpenApiSchema
            {
                Type = "String"
            }
        });
    }
}
