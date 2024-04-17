using Microsoft.EntityFrameworkCore;
using RKT.Model;

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

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
