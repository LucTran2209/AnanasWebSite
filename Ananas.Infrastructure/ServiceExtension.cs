using Ananas.Core.Common;
using Ananas.Core.Interfaces;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Ananas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IMarketRepository, MarketRepository>();
            services.AddScoped<IStyleRepository, IStyleRepository>();

            return services;
        }
    }
}
