namespace Company.Storage.Database.Configuration
{
    using Entities;

    public class CompanyMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Company>
    {
        public CompanyMapping()
            : this("dbo")
        {
        }

        public CompanyMapping(string schema)
        {
            ToTable("Company", schema);
            HasKey(x => x.Id);

            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(150);
            Property(x => x.Number).HasColumnName(@"Number").HasColumnType("nvarchar").IsRequired().HasMaxLength(100);

            Ignore(b => b.DomainEvents);

        }
    }
}