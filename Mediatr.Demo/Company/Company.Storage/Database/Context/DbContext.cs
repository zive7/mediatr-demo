namespace Company.Storage.Database.Context
{
    using Entities;
    using Company.Storage.Database.Configuration;

    public class DbContext : System.Data.Entity.DbContext, IDbContext
    {
        public System.Data.Entity.DbSet<Company> Companies { get; set; }

        public DbContext() : base("Name=MediatrDemoDb")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbContext(string connectionString)
            : base(connectionString)
        {

        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CompanyMapping());
        }
    }
}
