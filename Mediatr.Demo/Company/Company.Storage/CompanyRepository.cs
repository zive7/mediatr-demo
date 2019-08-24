namespace Company.Storage
{
    using Company.Entities.Storage;
    using Company.Storage.Database.Context;
    using Company.Storage.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public CompanyRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public void Insert(Company.Entities.Company company)
        {
            Entities.Company dbCompany = CompanyFatory.CreateCompany(company);

            _context.Set<Entities.Company>().Add(dbCompany);
        }
    }
}