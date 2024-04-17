using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RKT.ZZTestApp
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRktConfigurations();
            services.AddRktDb();
        }
    }
}
