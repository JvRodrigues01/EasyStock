using EasyStock.Domain.Enterprise.Repositories;
using EasyStock.Domain.User.Repositories;
using EasyStock.Infrastructure.Context;
using EasyStock.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyStock.Infrastructure
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services
                .AddDb(connectionString)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();

            return services;
        }
    }
}
