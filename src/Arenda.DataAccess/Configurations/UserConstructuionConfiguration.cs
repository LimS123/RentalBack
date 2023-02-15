using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arenda.DataAccess.Configurations
{
    public class UserConstructuionConfiguration : IEntityTypeConfiguration<UserConstruction>
    {
        public void Configure(EntityTypeBuilder<UserConstruction> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.ConstructionId
            });

            builder.HasOne(x => x.User)
                    .WithMany(x => x.UserConstructions)
                    .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Construction)
                    .WithMany(x => x.UserConstructions)
                    .HasForeignKey(x => x.ConstructionId);

            builder.ToTable("UserConstructions");
        }
    }
}
