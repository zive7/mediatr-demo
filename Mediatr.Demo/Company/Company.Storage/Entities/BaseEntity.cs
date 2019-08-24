namespace Company.Storage.Entities
{
    using MediatR;
    using System;

    public abstract class BaseEntity
    {
        public int Id { get; protected internal set; }

        public System.Collections.Generic.IReadOnlyList<INotification> DomainEvents
        {
            get
            {
                return _domainEvents;
            }
        }

        private readonly System.Collections.Generic.List<INotification> _domainEvents;

        protected BaseEntity(System.Collections.Generic.IEnumerable<INotification> domainEvents)
        {
            _domainEvents = domainEvents == null ?
                new System.Collections.Generic.List<INotification>()
                : new System.Collections.Generic.List<INotification>(domainEvents);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}