using ControlServices.Core.Domain.Entities;
using ControlServices.Core.IContracts.Repositorys.ClientRepos;
using ControlServices.Infra.Data.Contexts.Repositorys.Base;

namespace ControlServices.Infra.Data.Contexts.Repositorys;

public class ClientRepository : Repository<Client>, ICreateClientRepository
{
    public ClientRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }
}
