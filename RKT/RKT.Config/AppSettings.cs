using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppSettings
    {
        public static IConfiguration LoadConfiguration()
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetAssembly(typeof(IServiceCollectionExtension))?.Location) ?? "";

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(assemblyLocation, "appsettings.json"), false, false)
                .Build();

            return configuration;
        }
    }
}
