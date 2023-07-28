using ControlServices.Core.Domain.Entities;
using ControlServices.Core.IContracts.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlServices.Infra.Data.Contexts.Repositorys;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected ApplicationDbContext _applicationDbContext;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> Delete(TEntity domain)
    {
        _applicationDbContext.Remove(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> FindById(Expression<Func<TEntity, bool>> predicate)
    {
        return await _applicationDbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate); ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<TEntity>> FindAll()
    {
        return await _applicationDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> Insert(TEntity domain)
    {
        _applicationDbContext.Add(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> Update(TEntity domain)
    {
        _applicationDbContext.Entry(domain).State = EntityState.Modified;

        _applicationDbContext.Update(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IQueryable<TEntity> Get()
    {
        return _applicationDbContext.Set<TEntity>().AsNoTracking();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task Save()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}
