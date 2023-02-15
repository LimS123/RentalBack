using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arenda.DataAccess.Configurations
{
    public class ConstructuionConfiguration : IEntityTypeConfiguration<Construction>
    {
        public void Configure(EntityTypeBuilder<Construction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CreatedAtUtc).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.HouseNumber).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Square).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.NumberOfRooms).IsRequired(false);
            builder.Property(x => x.Floor).IsRequired(false);

            builder.ToTable("Constructions");
        }
    }
}
