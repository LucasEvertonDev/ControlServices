using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Infra.Utils.Resources;
using FluentValidation;

namespace ControlServices.Infra.Plugins.FluentValidation.Clients;

public class CreateClientsValidator :  BaseValidator<CreateClientsModel>, IValidatorModel<CreateClientsModel>
{
    public CreateClientsValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceMessages.NameRequired);
    }
}
