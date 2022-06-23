namespace EvDekorasyonu.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        bool SaveChanges();

    }
}
