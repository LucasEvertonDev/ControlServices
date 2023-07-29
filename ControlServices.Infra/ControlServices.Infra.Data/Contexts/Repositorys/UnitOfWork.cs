using ControlServices.Core.IContracts.Repositorys;
using ControlServices.Infra.Utils.Utils;

namespace ControlServices.Infra.Data.Contexts.Repositorys;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _context;

	public UnitOfWork(ApplicationDbContext applicationDbContext)
	{
        _context = applicationDbContext;
	}

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.DisposeAsync();
    }
}
