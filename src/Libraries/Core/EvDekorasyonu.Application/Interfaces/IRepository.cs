using EvDekorasyonu.Domain;

namespace EvDekorasyonu.Application.Interfaces
{
    // Repository Design Pattern 
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        void Insert(IEnumerable<T> entities);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);
        Task InsertManyAsync(IEnumerable<T> entities);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Update(IEnumerable<T> entities);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        void Delete(IEnumerable<T> entities);
        Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities);

        public IUnitOfWork UnitOfWork { get; }
    }

}
