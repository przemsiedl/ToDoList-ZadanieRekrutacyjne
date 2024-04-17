using Microsoft.Extensions.Configuration;
using Rkt.Config;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRktConfigurations(this IServiceCollection services)
        {
            services.AddSingleton(AppSettings.GetDbConfiguration());
            return services;
        }
    }
}
