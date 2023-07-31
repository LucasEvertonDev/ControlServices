using ControlServices.Core.IContracts.Repositorys.ClientRepos;
using ControlServices.Core.IContracts.Repositorys.UserRepos;
using ControlServices.Infra.Data.Contexts.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class RepositorysConfig
{
    public static void RegisterRepositorys(this IServiceCollection services)
    {
        services.AddScoped<ICreateUsersRepository, UserRepository>();
        services.AddScoped<ILoginRepository, UserRepository>();
        services.AddScoped<ISearchUsersRepository, UserRepository>();


        services.AddScoped<ICreateClientRepository, ClientRepository>();
    }
}
