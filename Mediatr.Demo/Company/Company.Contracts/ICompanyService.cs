namespace Company.Contracts
{
    using Company.Contracts.Models;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(CompanyCreateRequest request);
    }
}