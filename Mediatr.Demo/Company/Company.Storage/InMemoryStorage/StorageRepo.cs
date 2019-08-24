namespace Company.Storage.InMemoryStorage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public static class StorageRepo
    {
        public static List<Company> Companies { get; } = new List<Company>();

        public static void AddCompany(Company company)
        {
            Companies.Add(company);
        }

        public static void RemoveCompany(Company company)
        {
            Companies.Remove(company);
        }
    }
}
