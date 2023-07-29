using ControlServices.Core.IContracts.Repositorys;
using ControlServices.Infra.Utils.Utils;
using System;

namespace ControlServices.Core.Application.Services;

public class BaseService
{
    private readonly IUnitOfWork _unitOfWork;

    public BaseService()
    {
        _unitOfWork = EngineContext.GetService<IUnitOfWork>();
    }

    public async Task OnTransactionAsync(Func<Task> func)
    {
        try
        {
            await func();

            await _unitOfWork.CommitAsync();
        }
        catch 
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<TRetorno> OnTransactionAsync<TRetorno>(Func<Task<TRetorno>> func)
    {
        try
        {
            var retorno = await func();

            await _unitOfWork.CommitAsync();

            return retorno;
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
