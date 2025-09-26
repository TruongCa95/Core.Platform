using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T :  BaseEntity
    {
        private readonly MySqlDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MySqlDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByIdsAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Update(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdsAsync(IEnumerable<Guid> ids)
        {
            var entitiesToDelete = await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
            _dbSet.RemoveRange(entitiesToDelete);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetListByIdAsync(IEnumerable<Guid> ids)
        {
            return _dbSet.Where(e => ids.Contains(e.Id));
        }

        public async Task<List<T>> GetListByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _dbSet.Where(predicate).ToList());
        }

        public Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetListByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbSet.FirstOrDefaultAsync(predicate);
            if (result != null)
                return result;
            else
                return null;
        }
    }
}
