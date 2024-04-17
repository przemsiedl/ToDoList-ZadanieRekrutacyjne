using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RKT.Config;
using RKT.ZZTestApp;

Console.WriteLine("Zadanie rekrutacyjne. Aplikacja startowa.");

var provider = BuildServices();

var dbConfiguration = provider.GetService<DbConfiguration>();

Console.WriteLine(dbConfiguration.ConnectionString);

IServiceProvider BuildServices()
{
    IConfiguration configuration = AppSettings.LoadConfiguration();

    ServiceCollection serviceCollection = new ServiceCollection();

    Startup startup = new Startup(configuration);
    startup.ConfigureServices(serviceCollection);

    var provider = serviceCollection.BuildServiceProvider();
    return provider;
}
