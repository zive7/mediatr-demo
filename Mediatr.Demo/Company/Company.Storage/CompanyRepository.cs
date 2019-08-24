namespace Company.Storage
{
    using Company.Entities;
    using Company.Entities.Storage;
    using Company.Storage.InMemoryStorage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyRepository : ICompanyRepository
    {
        public void Insert(Company company)
        {
            StorageRepo.Companies.Add(company);
        }
    }
}