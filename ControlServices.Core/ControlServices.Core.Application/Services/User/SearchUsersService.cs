using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.RouteParams.Users;

namespace ControlServices.Core.Application.Services.User;

public class SearchUsersService : BaseService, ISearchUsersService
{
    private readonly ISearchUsersRepository _searchUsersRepository;

    public SearchUsersService(ISearchUsersRepository searchUsersRepository)
    {
        this._searchUsersRepository = searchUsersRepository;
    }

    public async Task<List<SearchUsersModel>> ExecuteAsync()
    {
        return await OnTransactionAsync(async () =>
        {
            return await _searchUsersRepository.FindAllAsync(new UsersParams());
        });
    }

    public async Task<List<SearchUsersModel>> ExecuteAsync(UsersParams userParams)
    {
        return await OnTransactionAsync(async () =>
        {
            return await _searchUsersRepository.FindAllAsync(userParams);
        });
    }
}
