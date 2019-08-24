namespace Company.Entities.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICompanyRepository
    {
        void Insert(Company company);
    }
}