using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.IModels;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Utils.Exceptions;
using FluentValidation;

namespace ControlServices.Infra.Plugins.FluentValidation;

public class BaseValidator<TModel> : AbstractValidator<TModel>, IValidatorModel<TModel> where TModel : IModel
{
    public async Task ValidateModelAsync(TModel model)
    {
        var validationResult = await this.ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            throw new BusinessException(validationResult.Errors.Select(c => c.ErrorMessage).ToArray());
        }
    }
}
