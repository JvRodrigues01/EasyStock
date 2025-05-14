using EasyStock.Domain.Enterprise.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStock.Infrastructure.Mappings
{
    public class EnterpriseMapping : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.ToTable("Enterprises");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.FantasyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PhoneNumer)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(u => u.AddressId)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne(x => x.Enterprise)
                .HasForeignKey<Enterprise>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Users)
                .WithOne(u => u.Enterprise)
                .HasForeignKey(u => u.EnterpriseId)
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
