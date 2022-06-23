using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain;
using Microsoft.EntityFrameworkCore;

namespace EvDekorasyonu.Persistence.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        private bool _disposed;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Table => _dbSet.AsNoTracking().AsQueryable();

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
            return entity;
        }

        public virtual async Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities)
        {
            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entities);
            });
            return entities;
        }

        public IUnitOfWork UnitOfWork => _context;

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() => Update(entity));
        }

        public virtual async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            return await Task.Run(() =>
            {
                Update(entities);
                return entities;
            });
        }
        public virtual void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);

                _disposed = true;
            }

        }

    }
}
