using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Repositorys.UserRepos;

public interface ICreateUsersRepository
{
    Task<CreateUsersModel> CreateAsync(CreateUsersModel userModel);
}
