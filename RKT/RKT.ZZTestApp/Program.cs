using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rkt.Config;
using RKT.Db;
using RKT.Services.Interfaces;
using RKT.ZZTestApp;

Console.WriteLine("Zadanie rekrutacyjne. Aplikacja startowa.");

var provider = BuildServices();

var service = provider.GetService<IToDoItemService>();

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
