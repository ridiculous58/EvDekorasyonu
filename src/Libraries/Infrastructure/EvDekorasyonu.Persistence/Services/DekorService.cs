using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;

namespace EvDekorasyonu.Persistence.Services
{
    public class DekorService : IDekorService
    {
        private readonly IRepository<Dekor> _repository;

        public IQueryable<Dekor> Table => _repository.Table;

        public DekorService(IRepository<Dekor> repository)
        {
            _repository = repository;
        }

        public async Task<Dekor> GetDekorByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Dekor>> GetDekorAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Dekor> InsertAsync(Dekor dekor)
        {
            var addedDekor = await _repository.InsertAsync(dekor);
            await _repository.UnitOfWork.SaveChangesAsync();
            return addedDekor;
        }

        public async Task InsertManyAsync(IEnumerable<Dekor> dekors)
        {
            await _repository.InsertManyAsync(dekors);
            await _repository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteById(string id)
        {
            if (!Guid.TryParse(id, out var idGuid))
                return false;

            var dekor = await _repository.GetByIdAsync(idGuid);

            if (dekor == null)
                return false;

            await _repository.DeleteAsync(dekor);
            await _repository.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Dekor> UpdateAsync(Dekor dekor)
        {
            var updatedDekor = await _repository.UpdateAsync(dekor);
            await _repository.UnitOfWork.SaveChangesAsync();
            return updatedDekor;
        }
    }
}