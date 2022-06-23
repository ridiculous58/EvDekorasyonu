using EvDekorasyonu.Domain.Entities;

namespace EvDekorasyonu.Application.Interfaces
{
    public interface IDekorService
    {
        Task<Dekor> GetDekorByIdAsync(Guid id);
        public IQueryable<Dekor> Table { get; }
        Task<IEnumerable<Dekor>> GetDekorAllAsync();
        Task<Dekor> InsertAsync(Dekor dekor);
        Task InsertManyAsync(IEnumerable<Dekor> dekors);
        Task<bool> DeleteById(string id);
        Task<Dekor> UpdateAsync(Dekor dekor);

    }
}
