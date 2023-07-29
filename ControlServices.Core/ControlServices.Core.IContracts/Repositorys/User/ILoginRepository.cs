using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Repositorys.User;

public interface ILoginRepository
{
    Task<UserModel> LoginAsync(LoginModel loginModel);
}
