namespace Company.Entities
{
    using Core.Contracts.Enums;
    using global::Company.Entities.DomainEvents;
    using global::Company.Entities.ValueObjects;

    public class Company : BaseEntity
    {
        public CompanyNameValue Name { get; private set; }

        public string Number { get; private set; }

        private Company()
        {

        }

        public static Company Create(CompanyNameValue name, string number)
        {
            Company company = new Company()
            {
                State = EntityState.Added,
                Name = name,
                Number = number
            };

            company.AddDomainEvent(new CompanyCreatedDomainEvent(name));
            return company;
        }
    }
}