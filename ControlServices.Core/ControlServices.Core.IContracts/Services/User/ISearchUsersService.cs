using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.RouteParams.Users;

namespace ControlServices.Core.IContracts.Services.User;

public interface ISearchUsersService
{
    Task<List<SearchUsersModel>> ExecuteAsync();

    Task<List<SearchUsersModel>> ExecuteAsync(UsersParams userParams);
}
