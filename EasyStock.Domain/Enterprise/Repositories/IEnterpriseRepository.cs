namespace EasyStock.Domain.Enterprise.Repositories
{
    public interface IEnterpriseRepository
    {
        Task AddAsync(Entities.Enterprise enterprise);
        Task<Entities.Enterprise> GetByIdAsync(Guid enterpriseId);
        Task<Entities.Enterprise> GetByEmailAsync(string email);
    }
}
