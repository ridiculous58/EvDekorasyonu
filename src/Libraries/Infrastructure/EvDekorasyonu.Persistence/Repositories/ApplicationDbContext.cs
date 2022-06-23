using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EvDekorasyonu.Persistence.Repositories
{
    public class ApplicationDbContext : IdentityDbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Dekor> Dekors { get; set; }
        public DbSet<DekorCategory> DekorCategories { get; set; }

        public async Task<bool> SaveChangesAsync()
        {
            await base.SaveChangesAsync();
            return true;
        }
        bool IUnitOfWork.SaveChanges()
        {
            SaveChanges();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }


    }
}
