using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateByIdsAsync(IEnumerable<T> entities);
        Task DeleteAsync(Guid id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteByIdsAsync(IEnumerable<Guid> ids);
        IQueryable<T> GetListByIdAsync(IEnumerable<Guid> ids);
        IQueryable<T> GetListByCondition(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter, int page, int pageSize);
        Task<T?> GetOne(Expression<Func<T, bool>> predicate);
    }
}
