using EasyStock.Domain.Address.Entities;
using EasyStock.Domain.Enterprise.Entities;
using EasyStock.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStock.Infrastructure.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.ZipCode)
               .IsRequired()
               .HasMaxLength(8);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.UserId)
                .IsRequired(false);

            builder.Property(a => a.EnterpriseId)
                .IsRequired(false);

            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<User>(u => u.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Enterprise)
                .WithOne(e => e.Address)
                .HasForeignKey<Enterprise>(e => e.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

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
