using Microsoft.Extensions.Configuration;
using RKT.Config;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRktConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton(GetDbConfiguration(configuration));
            return services;
        }

        private static DbConfiguration GetDbConfiguration(IConfiguration configuration)
        {
            DbConfiguration dbConfiguration = new DbConfiguration();
            configuration.GetSection(nameof(DbConfiguration)).Bind(dbConfiguration);
            return dbConfiguration;
        }
    }
}
