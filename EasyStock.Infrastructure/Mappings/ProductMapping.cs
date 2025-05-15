using EasyStock.Domain.Product.Entities;
using EasyStock.Domain.Stock.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStock.Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.Sku)
                .IsUnique();

            builder.Property(p => p.CostPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.SalePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Unit)
                .HasConversion<short>()
                .IsRequired();

            builder.Property(p => p.EnterpriseId)
                .IsRequired();

            builder.HasOne(p => p.Enterprise)
                .WithMany(e => e.Products)
                .HasForeignKey(p => p.EnterpriseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Stock)
                .WithOne(s => s.Product)
                .HasForeignKey<Stock>(s => s.ProductId)
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
