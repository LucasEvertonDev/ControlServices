using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Repositorys.User;

public interface ICreateUserRepository
{
    Task<CreateUserModel> CreateAsync(CreateUserModel userModel);
}
