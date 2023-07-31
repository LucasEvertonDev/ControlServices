using ControlServices.Infra.Plugins.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class AutoMapperConfig 
{
    public static void RegisterAutoMappper(this IServiceCollection services)
    {
        services.AddScoped<ControlServices.Core.IContracts.Mapper.IMapper, ControlServices.Infra.Plugins.AutoMapper.Mapper>();

        services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        }).CreateMapper());
    }
}

