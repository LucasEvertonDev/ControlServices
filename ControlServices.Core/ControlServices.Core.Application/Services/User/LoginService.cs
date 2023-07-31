using ControlServices.Core.IContracts.Repositorys.UserRepos;
using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.IContracts.UnitOfWork;
using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.Application.Services.User;

public class LoginService : BaseService, ILoginService
{
    private readonly IValidatorModel<LoginModel> _loginValidatorModel;
    private readonly ILoginRepository _loginRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginService(IValidatorModel<LoginModel> loginValidatorModel,
        ILoginRepository searchUserRepositor,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        this._loginValidatorModel = loginValidatorModel;
        this._loginRepository = searchUserRepositor;
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<TokenModel> ExecuteAsync(LoginModel loginModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(loginModel);

            var user = await _loginRepository.LoginAsync(loginModel);

            return await _jwtTokenGenerator.GenerateTokenJWT(email: user.Login);
        });
    }

    protected async Task ValidateAsync(LoginModel model)
    {
        await _loginValidatorModel.ValidateModelAsync(model);
    }
}
