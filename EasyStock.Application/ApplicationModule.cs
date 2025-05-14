using EasyStock.Domain.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyStock.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule)));

            return services;
        }
    }
}
