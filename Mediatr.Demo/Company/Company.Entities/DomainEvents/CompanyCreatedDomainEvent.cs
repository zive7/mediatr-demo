namespace Company.Entities.DomainEvents
{
    using MediatR;

    public class CompanyCreatedDomainEvent : INotification
    {
        public string Name { get; }

        public CompanyCreatedDomainEvent(string name)
        {
            Name = name;
        }
    }
}