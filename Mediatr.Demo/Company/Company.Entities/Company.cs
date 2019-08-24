namespace Company.Entities
{
    using global::Company.Entities.DomainEvents;
    using global::Company.Entities.ValueObjects;

    public class Company : BaseEntity
    {
        public CompanyNameValue Name { get; private set; }

        public decimal Number { get; private set; }

        private Company()
        {

        }

        public static Company Create(CompanyNameValue name, decimal number)
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