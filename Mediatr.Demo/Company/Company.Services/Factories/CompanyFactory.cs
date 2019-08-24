namespace Company.Services.Factories
{
    using Company.Contracts.Models;
    using Company.Entities.ValueObjects;

    internal static class CompanyFactory
    {
        internal static Entities.Company CreateCompany(CompanyCreateRequest request)
        {
            return Entities.Company.Create(CompanyNameValue.Create(request.Name),
                                            request.Number);
        }
    }
}