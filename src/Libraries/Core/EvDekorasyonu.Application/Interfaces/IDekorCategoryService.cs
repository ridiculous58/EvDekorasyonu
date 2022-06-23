using EvDekorasyonu.Domain.Entities;

namespace EvDekorasyonu.Application.Interfaces;

public interface IDekorCategoryService
{
    Task<DekorCategory> GetDekorCategoryByIdAsync(Guid id);
    Task<IEnumerable<DekorCategory>> GetDekorCategoryAllAsync();
    Task<DekorCategory> InsertAsync(DekorCategory dekor);
    Task InsertManyAsync(IEnumerable<DekorCategory> dekors);
}