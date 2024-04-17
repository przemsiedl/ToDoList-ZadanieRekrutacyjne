using Microsoft.Extensions.Configuration;
using RKT.Config;
using System.Reflection;

namespace Rkt.Config
{
    public static class AppSettings
    {
        private static IConfiguration? _configuration;


        public static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                _configuration = LoadConfiguraiton();
            }
            return _configuration;
        }

        public static DbConfiguration GetDbConfiguration()
        {
            IConfiguration configuration = GetConfiguration();
            DbConfiguration dbConfiguration = new DbConfiguration();
            configuration.GetSection(nameof(DbConfiguration)).Bind(dbConfiguration);
            return dbConfiguration;
        }

        private static IConfiguration LoadConfiguraiton()
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetAssembly(typeof(AppSettings))?.Location) ?? "";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(assemblyLocation, "appsettings.json"), false, false)
                .Build();
            return configuration;
        }
    }
}
