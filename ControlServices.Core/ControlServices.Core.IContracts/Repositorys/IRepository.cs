using ControlServices.Core.Domain.IEntities;
using System.Linq.Expressions;

namespace ControlServices.Core.IContracts.Repositorys;

public interface IRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IQueryable<T> Get();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task Save();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> FindById(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> Insert(T domain);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> Update(T domain);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> Delete(T domain);
}
