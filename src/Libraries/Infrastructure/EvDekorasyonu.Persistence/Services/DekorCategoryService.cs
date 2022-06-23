using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;

namespace EvDekorasyonu.Persistence.Services;

public class DekorCategoryService : IDekorCategoryService
{
    private readonly IRepository<DekorCategory> _repository;


    public DekorCategoryService(IRepository<DekorCategory> repository)
    {
        _repository = repository;
    }

    public Task<DekorCategory> GetDekorCategoryByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<IEnumerable<DekorCategory>> GetDekorCategoryAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task<DekorCategory> InsertAsync(DekorCategory dekor)
    {
        var dekorCategory = await _repository.InsertAsync(dekor);
        await _repository.UnitOfWork.SaveChangesAsync();
        return dekorCategory;
    }

    public Task InsertManyAsync(IEnumerable<DekorCategory> dekors)
    {
        _repository.InsertManyAsync(dekors);
        return _repository.UnitOfWork.SaveChangesAsync();
    }

}