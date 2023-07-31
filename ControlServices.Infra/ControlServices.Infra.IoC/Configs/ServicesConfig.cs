using ControlServices.Core.Application.Services.Clients;
using ControlServices.Core.Application.Services.User;
using ControlServices.Core.IContracts.Services.Clients;
using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Infra.Plugins.TokenJWT;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class ServicesConfig
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<ICreateUsersService, CreateUsersService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ISearchUsersService, SearchUsersService>();

        services.AddScoped<ICreateClientsService, CreateClientsService>();
    }
}

