using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.Application.Services.User;

public class CreateUsersService : BaseService, ICreateUsersService
{
    private readonly IValidatorModel<CreateUsersModel> _createUserValidatorModel;
    private readonly ICreateUsersRepository _createUserRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public CreateUsersService(IValidatorModel<CreateUsersModel> createUserValidatorModel,
        ICreateUsersRepository createUserRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        this._createUserValidatorModel = createUserValidatorModel;
        this._createUserRepository = createUserRepository;
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<TokenModel> ExecuteAsync(CreateUsersModel userModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(userModel);

            await _createUserRepository.CreateAsync(userModel);

            return await _jwtTokenGenerator.GenerateTokenJWT(email: userModel.Login);
        });
    }

    protected async Task ValidateAsync(CreateUsersModel userModel)
    {
        await _createUserValidatorModel.ValidateModelAsync(userModel);
    }
}
