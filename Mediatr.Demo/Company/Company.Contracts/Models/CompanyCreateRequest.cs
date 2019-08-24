namespace Company.Contracts.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CompanyCreateRequest
    {
        public string Name { get; set; }

        public decimal Number { get; set; }
    }
}