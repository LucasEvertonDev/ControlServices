using ControlServices.Core.IContracts.UnitOfWork;
using ControlServices.Infra.Utils.Utils;

namespace ControlServices.Infra.Data.Contexts.UnitOfWork;

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
