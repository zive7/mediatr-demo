namespace Company.Entities
{
    using global::Company.Entities.DomainEvents;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Company : BaseEntity
    {
        public string Name { get; private set; }

        public decimal Number { get; private set; }

        private Company()
        {

        }

        public static Company Create(string name, decimal number)
        {
            Company company = new Company()
            {
                Id = 1,
                Name = name,
                Number = number
            };

            company.AddDomainEvent(new CompanyCreatedDomainEvent(name));
            return company;
        }
    }
}