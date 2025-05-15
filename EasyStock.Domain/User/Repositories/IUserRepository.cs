namespace EasyStock.Domain.User.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(Entities.User user);
        Task<Entities.User> GetByIdAsync(Guid userId);
        Task<Entities.User> GetByEmailAsync(string email);
    }
}
