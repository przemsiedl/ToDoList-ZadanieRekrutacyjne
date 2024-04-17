namespace RKT.Db
{
    public interface IDbContextFactory
    {
        RktDbContext NewContext();
    }
}
