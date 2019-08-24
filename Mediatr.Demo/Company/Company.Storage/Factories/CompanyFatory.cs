using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Entities;
using Company.Storage.Entities;

namespace Company.Storage.Factories
{
    internal static class CompanyFatory
    {
        internal static Entities.Company CreateCompany(Company.Entities.Company company)
        {
            return new Entities.Company(company.DomainEvents)
            {
                Id = company.Id,
                Name = company.Name,
                Number = company.Number
            };
        }
    }
}
