using EasyStock.Domain.Enterprise.Entities;
using EasyStock.Domain.Enterprise.Repositories;
using EasyStock.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyStock.Infrastructure.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly AppDbContext _context;

        public EnterpriseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Enterprise enterprise)
        {
            await _context.Enterprises.AddAsync(enterprise);
            await _context.SaveChangesAsync();
        }

        public async Task<Enterprise> GetByIdAsync(Guid enterpriseId)
        {
            return await _context.Enterprises.FindAsync(enterpriseId);
        }

        public async Task<Enterprise> GetByEmailAsync(string email)
        {
            return await _context.Enterprises.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
