using ControlServices.Infra.IoC.SwaggerFilters;
using ControlServices.Infra.Utils.Utils;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text.Json;

namespace ControlServices.Infra.IoC.Configs
{
    public static class DocumentationConfig
    {
        public static void RegisterDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
           
                c.ExampleFilters();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CpontrolServices.API", Version = "v1" });

                // add Security information to each operation for OAuth2
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.OperationFilter<AcceptLanguageHeaderFilter>();

                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                c.DocInclusionPredicate((name, api) => true);

                c.OperationFilter<SwaggerDefaultValues>();

                var xmlFilename = $"{EngineContext.Assembly}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: false);

            });

            services.AddSwaggerExamples();
        }
    }
}
