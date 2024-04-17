using RKT.Services;
using RKT.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRktServices(this IServiceCollection services)
        {
            services.AddSingleton<IToDoItemService, ToDoItemService>();

            return services;
        }
    }
}
