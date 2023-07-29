namespace ControlServices.Core.IContracts.Repositorys;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}
