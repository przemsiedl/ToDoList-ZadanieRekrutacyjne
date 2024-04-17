using Microsoft.Extensions.Logging;
using RKT.Db;

namespace RKT.Services
{
    public abstract class ServiceBase<TService>
    {
        protected IDbContextFactory Factory { get; }
        protected ILogger<TService> Logger { get; }

        protected ServiceBase(IDbContextFactory factory, ILogger<TService> logger)
        {
            Factory = factory;
            Logger = logger;
        }

    }
}
