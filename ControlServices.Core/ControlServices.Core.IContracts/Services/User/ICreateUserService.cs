using ControlServices.Core.IContracts.Services.Base;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Services.User;

public interface ICreateUserService: IServiceBase<TokenModel, CreateUserModel>
{
}
