using ControlServices.Core.Domain.IEntities;

namespace ControlServices.Core.IContracts.Repositorys.BaseRepos;
public interface IDeleteRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> Delete(T domain);
}
