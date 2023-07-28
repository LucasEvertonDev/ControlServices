using ControlServices.Core.Models.IModels;

namespace ControlServices.Core.IContracts.Services.Base;

public interface IServiceBase<TResponse, TRequest> where TResponse : IModel where TRequest : IModel
{
    Task<TResponse> ExecuteAsync(TRequest model);
}
