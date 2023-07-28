using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Plugins.FluentValidation.CustomValidators;
using ControlServices.Infra.Utils.Resources;
using FluentValidation;

namespace ControlServices.Infra.Plugins.FluentValidation.User;

public class CreateUserValidator: BaseValidator<CreateUserModel>, IValidatorModel<CreateUserModel>
{
    public CreateUserValidator()
    {
        RuleFor(c => c.UserName).NotEmpty().WithMessage(ResourceMessages.UserNameRequired);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMessages.EmailRequired);
        RuleFor(c => c.Password).SetValidator(new PasswordValidator());
    }
}
