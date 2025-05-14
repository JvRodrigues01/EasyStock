using EasyStock.Domain.Address.Entities;
using EasyStock.Domain.Enterprise.Entities;
using EasyStock.Domain.User.Entities;
using EasyStock.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EasyStock.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new EnterpriseMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
        }
    }
}
