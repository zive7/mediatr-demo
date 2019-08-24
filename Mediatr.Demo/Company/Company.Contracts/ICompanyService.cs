namespace Company.Contracts
{
    using Company.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(CompanyCreateRequest request);
    }
}
