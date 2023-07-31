namespace ControlServices.Core.IContracts.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}
