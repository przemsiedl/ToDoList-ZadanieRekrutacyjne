using RKT.Db;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRktDb(this IServiceCollection services)
        {
            services.AddDbContext<RktDbContext>();
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            return services;
        }
    }
}
