using ControlServices.Core.Domain.IEntities;

namespace ControlServices.Core.IContracts.Repositorys.BaseRepos;

public interface ICreateRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> CreateAsync(T domain);
}
