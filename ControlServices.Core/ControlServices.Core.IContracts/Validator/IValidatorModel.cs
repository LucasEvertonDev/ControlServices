using ControlServices.Core.Models.IModels;

namespace ControlServices.Core.IContracts.Validator;

public interface IValidatorModel<TModel> where TModel : IModel
{
    Task ValidateModelAsync(TModel model);
}
