using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rkt.Config;
using RKT.Db;
using RKT.ZZTestApp;

Console.WriteLine("Zadanie rekrutacyjne. Aplikacja startowa.");

var provider = BuildServices();

var factory = provider.GetService<IDbContextFactory>();
var context = factory.NewContext();


Console.WriteLine();

IServiceProvider BuildServices()
{
    IConfiguration configuration = AppSettings.GetConfiguration();

    ServiceCollection serviceCollection = new ServiceCollection();

    Startup startup = new Startup(configuration);
    startup.ConfigureServices(serviceCollection);

    var provider = serviceCollection.BuildServiceProvider();
    return provider;
}
