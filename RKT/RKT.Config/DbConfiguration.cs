namespace RKT.Config
{
    public class DbConfiguration
    {
        public bool UseSqLite => true;
        public bool CreateDatabase => true;
        public string? ConnectionString { get; set; }
    }
}
