using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Plugins.FluentValidation.CustomValidators;
using ControlServices.Infra.Utils.Resources;
using FluentValidation;

namespace ControlServices.Infra.Plugins.FluentValidation.User;

public class LoginValidator : BaseValidator<LoginModel>, IValidatorModel<LoginModel>
{
    public LoginValidator()
    {
        RuleFor(c => c.Login).SetValidator(new UserNameValidator());
        RuleFor(c => c.Password).SetValidator(new PasswordValidator());
    }
}
