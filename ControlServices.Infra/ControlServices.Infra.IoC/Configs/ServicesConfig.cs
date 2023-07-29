using ControlServices.Core.Application.Services.User;
using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Infra.Data.Token;
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
    }
}

