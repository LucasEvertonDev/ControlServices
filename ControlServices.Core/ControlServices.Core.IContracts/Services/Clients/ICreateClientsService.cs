
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Core.Models.Models.Clients.Base;

namespace ControlServices.Core.IContracts.Services.Clients;

public interface ICreateClientsService
{
    Task<ClientModel> ExecuteAsync(CreateClientsModel clientsModel);
}
