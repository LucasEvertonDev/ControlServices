using ControlServices.Core.Models.Models.Base;
using ControlServices.Core.Models.Models.Token;

namespace ControlServices.Core.IContracts.Services.Token;

public interface IJwtTokenGenerator
{
    Task<TokenModel> GenerateTokenJWT(string email);
}
