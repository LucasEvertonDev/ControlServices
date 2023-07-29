using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Services.User;

public interface ICreateUsersService
{
    Task<TokenModel> ExecuteAsync(CreateUsersModel userModel);
}
