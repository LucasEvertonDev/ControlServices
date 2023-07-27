using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ControlServices.Infra.IoC.Configs
{
    public static class DocumentationConfig
    {
        public static void RegisterDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Control Services",
                    Description = "Api Control Services",
                    Contact = new OpenApiContact
                    {
                        Name = "lcseverton",
                        Url = new Uri("https://www.lcseverton.com.br/contato"),
                        Email = "contato@lcseverton.com.br"
                    }
                });
            });
        }
    }
}
