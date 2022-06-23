using EvDekorasyonu.Domain.Entities;
using EvDekorasyonu.Persistence.Repositories.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvDekorasyonu.Persistence.Repositories.EntityTypeConfigurations.DekorCategoryMap
{
    public class DekorCategoryMap : BaseEntityMap<DekorCategory>
    {
        public override void Configure(EntityTypeBuilder<DekorCategory> builder)
        {

            builder.HasIndex(f => f.Name).IncludeProperties(x => x.Description).HasFillFactor(70).HasDatabaseName("IX1_NAME");
            base.Configure(builder);


        }
    }
}
