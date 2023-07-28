using ControlServices.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class DbContextConfig
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        //É obrigatório definir a versão do My Sql 
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
               ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
    }
}
