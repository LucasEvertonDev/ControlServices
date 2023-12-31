﻿using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Plugins.FluentValidation.CustomValidators;
using ControlServices.Infra.Utils.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace ControlServices.Infra.Plugins.FluentValidation.User;

public class CreateUserValidator: BaseValidator<CreateUsersModel>, IValidatorModel<CreateUsersModel>
{
    public CreateUserValidator()
    {
        RuleFor(c => c.Login).SetValidator(new UserNameValidator());
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMessages.EmailRequired);
        RuleFor(c => c.Password).SetValidator(new PasswordValidator());

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMessages.UserEmailInvalid);
        });
    }
}
