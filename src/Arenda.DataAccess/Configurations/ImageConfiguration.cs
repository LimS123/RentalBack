using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arenda.DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.MediaType).IsRequired();
            builder.Property(x => x.Data).IsRequired();

            builder.HasOne(x => x.Construction)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ConstructionId);

            builder.ToTable("Images");
        }
    }
}
