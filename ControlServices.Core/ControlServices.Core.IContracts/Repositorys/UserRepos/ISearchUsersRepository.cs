using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.RouteParams.Users;

namespace ControlServices.Core.IContracts.Repositorys.UserRepos;

public interface ISearchUsersRepository
{
    Task<List<SearchUsersModel>> FindAllAsync(UsersParams usersParams);
}
