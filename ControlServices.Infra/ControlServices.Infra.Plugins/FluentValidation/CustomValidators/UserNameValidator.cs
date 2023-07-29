using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Utils.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace ControlServices.Infra.Plugins.FluentValidation.CustomValidators;

internal class UserNameValidator : AbstractValidator<string>
{
    public UserNameValidator()
    {
        RuleFor(UserName => UserName).NotEmpty().WithMessage(ResourceMessages.UserNameRequired);
        When(UserName => !string.IsNullOrWhiteSpace(UserName), () =>
        {
            RuleFor(UserName => UserName).Custom((username, contexto) =>
            {
                if (username.Contains(" "))
                {
                    contexto.AddFailure(new ValidationFailure(nameof(CreateUsersModel.Login), ResourceMessages.UserNameInvalid));
                }

                if (username.Length < 5)
                {
                    contexto.AddFailure(new ValidationFailure(nameof(CreateUsersModel.Login), ResourceMessages.UserNameMinLenght));
                }
            });
        });
    }
}
