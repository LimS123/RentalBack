using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arenda.DataAccess.Configurations
{
    public class UserOrderConfiguration : IEntityTypeConfiguration<UserOrder>
    {
        public void Configure(EntityTypeBuilder<UserOrder> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.ConstructionId,
                x.OrderId
            });

            builder.HasOne(x => x.User)
                    .WithMany(x => x.UserOrders)
                    .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Construction)
                    .WithMany(x => x.UserOrders)
                    .HasForeignKey(x => x.ConstructionId);

            builder.HasOne(x => x.Order)
                    .WithMany(x => x.UserOrders)
                    .HasForeignKey(x => x.OrderId);

            builder.ToTable("UserOrders");
        }
    }
}
