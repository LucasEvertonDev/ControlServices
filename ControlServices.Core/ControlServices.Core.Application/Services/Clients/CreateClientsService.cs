using ControlServices.Core.Domain.Entities;
using ControlServices.Core.IContracts.Mapper;
using ControlServices.Core.IContracts.Repositorys.ClientRepos;
using ControlServices.Core.IContracts.Services.Clients;
using ControlServices.Core.IContracts.UnitOfWork;
using ControlServices.Core.IContracts.Validator;
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Core.Models.Models.Clients.Base;

namespace ControlServices.Core.Application.Services.Clients;

public class CreateClientsService : BaseService, ICreateClientsService
{
    private ICreateClientRepository _createClientRepository;
    private readonly IValidatorModel<CreateClientsModel> _createClientsValidatorModel;
    private readonly IMapper _mapper;

    public CreateClientsService(ICreateClientRepository createClientRepository,
        IValidatorModel<CreateClientsModel> createClientsValidatorModel,
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        this._createClientRepository = createClientRepository;
        this._createClientsValidatorModel = createClientsValidatorModel;
        this._mapper = mapper;
    }

    public async Task<ClientModel> ExecuteAsync(CreateClientsModel clientsModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(clientsModel);

            var client =_mapper.Map<Client>(clientsModel);

            client = await _createClientRepository.CreateAsync(client);

            return _mapper.Map<ClientModel>(client);
        });
    }

    protected async Task ValidateAsync(CreateClientsModel clientsModel)
    {
        await _createClientsValidatorModel.ValidateModelAsync(clientsModel);
    }
}
