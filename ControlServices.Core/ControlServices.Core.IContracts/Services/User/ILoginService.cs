using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Services.User;

public interface ILoginService
{
    Task<TokenModel> ExecuteAsync(LoginModel loginModel);
}
