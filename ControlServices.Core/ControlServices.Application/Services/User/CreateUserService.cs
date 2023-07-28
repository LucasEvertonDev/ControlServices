using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Data.Token;

namespace ControlServices.Core.Application.Services.User;

public class CreateUserService : BaseService<CreateUserModel>, ICreateUserService
{
    private readonly IValidatorModel<CreateUserModel> _createUserValidatorModel;
    private readonly ICreateUserRepository _createUserRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public CreateUserService(IValidatorModel<CreateUserModel> createUserValidatorModel,
        ICreateUserRepository createUserRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        this._createUserValidatorModel = createUserValidatorModel;
        this._createUserRepository = createUserRepository;
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<TokenModel> ExecuteAsync(CreateUserModel userModel)
    {
        await Validate(userModel);

        await _createUserRepository.CreateAsync(userModel);

        return await _jwtTokenGenerator.GenerateTokenJWT(email: userModel.Email);
    }

    protected async override Task Validate(CreateUserModel userModel)
    {
        await _createUserValidatorModel.ValidateModelAsync(userModel);
    }
}
