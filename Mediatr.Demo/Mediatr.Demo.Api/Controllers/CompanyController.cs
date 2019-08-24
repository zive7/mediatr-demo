namespace Mediatr.Demo.Api.Controllers
{
    using Company.Contracts;
    using Company.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/companies")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpPost]
        [Route("")]
        public async Task CreateCompanyAsync([FromBody] CompanyCreateRequest request)
        {
            await _companyService.CreateCompanyAsync(request);
        }
    }
}