using ControlServices.Core.IContracts.Services.Base;
using ControlServices.Core.Models.IModels;

namespace ControlServices.Core.Application.Services;

public abstract class BaseService<TRequest> where TRequest : IModel
{
    protected abstract Task Validate(TRequest model);
}