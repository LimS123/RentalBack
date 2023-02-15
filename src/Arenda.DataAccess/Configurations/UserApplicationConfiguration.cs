using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arenda.DataAccess.Configurations
{
    public class UserApplicationConfiguration : IEntityTypeConfiguration<UserApplication>
    {
        public void Configure(EntityTypeBuilder<UserApplication> builder)
        {
            builder.HasKey(x => new
            {
                x.ApplicationId,
                x.UserId
            });

            builder.HasOne(x => x.User)
                    .WithMany(x => x.UserApplications)
                    .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Application)
                    .WithMany(x => x.UserApplications)
                    .HasForeignKey(x => x.ApplicationId);

            builder.ToTable("UserApplications");
        }
    }
}
