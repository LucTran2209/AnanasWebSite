using Ananas.Core.Common;
using Ananas.Core.Interfaces;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Ananas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.AccessControl;

namespace Ananas.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnanasDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
            });
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IColorRepository, ColorRepository>();
            //services.AddScoped<IMarketRepository, MarketRepository>();
            //services.AddScoped<IStyleRepository, StyleRepository>();
            //services.AddScoped<ICollectionRepository, CollectionRepository>();
            //services.AddScoped<ISexRepository, SexRepository>();
            //services.AddScoped<ISizeRepository, SizeRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IDiscountRepository, DiscountRepository>();

            RegisterRepositories(services);

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // Tải assembly chứa các interface repository
            var interfaceAssembly = Assembly.Load("Ananas.Core");

            // Tải assembly chứa các class repository
            var implementationAssembly = Assembly.Load("Ananas.Infrastructure");

            // Lấy tất cả các interface kế thừa từ IGenericRepository<>
            var repositoryInterfaces = interfaceAssembly.GetTypes()
                .Where(t => t.IsInterface && t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGenericRepository<>)))
                .ToList();

            // Lấy tất cả các class kế thừa từ GenericRepository<>
            var repositoryClasses = implementationAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(GenericRepository<>))
                .ToList();

            // Register each repository
            foreach (var repositoryInterface in repositoryInterfaces)
            {
                var implementationType = repositoryClasses.FirstOrDefault(t => repositoryInterface.IsAssignableFrom(t));
                if (implementationType != null)
                {
                    services.AddScoped(repositoryInterface, implementationType);
                }
            }
        }

    }
}
