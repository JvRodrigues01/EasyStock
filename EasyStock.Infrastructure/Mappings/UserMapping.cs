using EasyStock.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStock.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(u => u.EnterpriseId)
                .IsRequired();

            builder.HasOne(u => u.Enterprise)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.EnterpriseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.AddressId)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.Active)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate");

            builder.Property(u => u.LastUpdate)
                .IsRequired()
                .HasColumnName("LastUpdate");
        }
    }
}
