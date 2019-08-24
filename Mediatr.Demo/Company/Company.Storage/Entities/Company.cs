using MediatR;

namespace Company.Storage.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; protected internal set; }

        public string Number { get; protected internal set; }

        protected internal Company() : this(new System.Collections.Generic.List<INotification>())
        {

        }

        protected internal Company(System.Collections.Generic.IEnumerable<INotification> domainEvents) : base(domainEvents)
        {
        }
    }
}
