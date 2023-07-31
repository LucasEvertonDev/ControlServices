using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Plugins.FluentValidation.Clients;
using ControlServices.Infra.Plugins.FluentValidation.User;
using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.IoC.Configs;

public static class ValidatorsConfig
{
    public static void RegisterValidations(this IServiceCollection services)
    {
        services.AddScoped<IValidatorModel<CreateUsersModel>, CreateUserValidator>();
        services.AddScoped<IValidatorModel<LoginModel>, LoginValidator>();
        services.AddScoped<IValidatorModel<CreateClientsModel>, CreateClientsValidator>();
    }
}
