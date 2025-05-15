using EasyStock.Domain.Stock.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyStock.Infrastructure.Mappings
{
    public class StockMapping : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.ProductId)
                .IsRequired();

            builder.HasOne(s => s.Product)
                .WithOne(p => p.Stock)
                .HasForeignKey<Stock>(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.Quantity)
                .HasPrecision(18, 3)
                .IsRequired();

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
