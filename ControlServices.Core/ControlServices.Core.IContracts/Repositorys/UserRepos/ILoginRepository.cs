using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Models.User.Base;

namespace ControlServices.Core.IContracts.Repositorys.UserRepos;

public interface ILoginRepository
{
    Task<UserModel> LoginAsync(LoginModel loginModel);
}
