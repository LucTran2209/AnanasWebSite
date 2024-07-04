using Microsoft.Extensions.DependencyInjection;

namespace Ananas.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperInfastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
