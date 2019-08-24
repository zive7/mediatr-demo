namespace Company.Services
{
    using Company.Contracts;
    using Company.Contracts.Models;
    using Company.Entities.Storage;
    using Company.Services.Factories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDispatchEventService _dispatchEventService;

        public CompanyService(ICompanyRepository companyRepository,
                              IDispatchEventService dispatchEventService)
        {
            _companyRepository = companyRepository;
            _dispatchEventService = dispatchEventService;
        }

        public async Task CreateCompanyAsync(CompanyCreateRequest request)
        {
            Entities.Company company = CompanyFactory.CreateCompany(request);

            _companyRepository.Insert(company);

            await _dispatchEventService.DispatchDomainEventsAsync(company.DomainEvents);
        }
    }
}