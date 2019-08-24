namespace Company.Services
{
    using Company.Contracts;
    using Company.Contracts.Models;
    using Company.Entities.Storage;
    using Company.Entities.UnitOfWork;
    using Company.Services.Factories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository,
                              IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCompanyAsync(CompanyCreateRequest request)
        {
            Entities.Company company = CompanyFactory.CreateCompany(request);

            _companyRepository.Insert(company);

            await _unitOfWork.SaveAsync();
        }
    }
}