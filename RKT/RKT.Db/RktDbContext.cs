using Microsoft.EntityFrameworkCore;

namespace RKT.Db
{
    public class RktDbContext : DbContext
    {
        public RktDbContext(DbContextOptions<RktDbContext> options) : base(options)
        {
        }
        public RktDbContext() : this(DbContextFactory.BuildOptions())
        {
        }

    }
}
