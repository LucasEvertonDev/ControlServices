using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Infra.Data.Contexts.Repositorys.User;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class RepositorysConfig
{
    public static void RegisterRepositorys(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserRepository, CreateUserRepository>();
    }
}
