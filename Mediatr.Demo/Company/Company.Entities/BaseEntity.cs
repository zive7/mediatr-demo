using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Entities
{
    public abstract class BaseEntity
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();

        public int Id { get; protected set; }

        public IReadOnlyList<INotification> DomainEvents => _domainEvents;

        protected void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        protected void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null)
            {
                return;
            }

            _domainEvents.Remove(eventItem);
        }
    }
}
