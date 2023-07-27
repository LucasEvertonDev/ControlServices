using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ControlServices.Infra.IoC.Configs;

namespace ControlServices.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        // Register db context
        services.RegisterDbContext(configuration);

        services.RegisterIdentity(configuration);

        services.RegisterDocumentation();

        return services;
    }
}
