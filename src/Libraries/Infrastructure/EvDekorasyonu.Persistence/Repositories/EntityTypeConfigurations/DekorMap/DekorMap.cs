using EvDekorasyonu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvDekorasyonu.Persistence.Repositories.EntityTypeConfigurations.DekorMap
{
    public class DekorMap : BaseEntityMap<Dekor>
    {
        public override void Configure(EntityTypeBuilder<Dekor> builder)
        {

            builder.Property(x => x.Description).IsRequired(false);
            builder.HasIndex(f => f.Name).IncludeProperties(x => x.ImageUrl).HasFillFactor(70).HasDatabaseName("IX1_NAME");
            base.Configure(builder);


        }
    }
}
