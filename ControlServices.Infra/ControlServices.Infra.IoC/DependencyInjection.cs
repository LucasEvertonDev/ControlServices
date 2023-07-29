using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ControlServices.Infra.IoC.Configs;
using ControlServices.Infra.Utils.Utils;

namespace ControlServices.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(option => option.LowercaseUrls = true);

        // Register db context
        services.RegisterDbContext(configuration);

        services.RegisterIdentity(configuration);

        services.RegisterValidations();

        services.RegisterDocumentation();

        services.RegisterApplicationServices();

        services.RegisterRepositorys();

        // Include services
        EngineContext.AddServices(services);

        return services;
    }
}
