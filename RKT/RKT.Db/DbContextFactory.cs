using Microsoft.EntityFrameworkCore;
using Rkt.Config;
using RKT.Config;

namespace RKT.Db
{
    public class DbContextFactory : IDbContextFactory
    {
        DbContextOptions<RktDbContext> options;
        DbConfiguration DbConfiguration;
        private Func<RktDbContext> NewDbContext { get; set; }
        public DbContextFactory(DbConfiguration configuration)
        {
            options = CreateOptions(configuration);
            DbConfiguration = configuration;
            NewDbContext = WithDbCreate;
        }


        public RktDbContext NewContext() => NewDbContext();


        private RktDbContext WithDbCreate()
        {
            var dbContext = new RktDbContext(options);

            if (DbConfiguration.CreateDatabase)
            {
                dbContext.Database.EnsureCreated();
            }

            NewDbContext = WithoutDbCreate;
            return dbContext;
        }

        private RktDbContext WithoutDbCreate()
        {
            return new RktDbContext(options);
        }

        private static DbContextOptions<RktDbContext> CreateOptions(DbConfiguration dbConfiguration)
        {
            if (dbConfiguration?.UseSqLite == true)
            {
                return new DbContextOptionsBuilder<RktDbContext>()
                    .UseSqlite(dbConfiguration.ConnectionString)
                    .Options;
            }

            return BuildOptions();
        }

        internal static DbContextOptions<RktDbContext> BuildOptions()
        {
            DbConfiguration configuration = AppSettings.GetDbConfiguration();
            DbContextOptionsBuilder<RktDbContext> builder = new DbContextOptionsBuilder<RktDbContext>().UseSqlite(configuration.ConnectionString);
            return builder.Options;
        }
    }
}
