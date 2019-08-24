using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Entities.DomainEvents
{
    public class CompanyCreatedDomainEvent : INotification
    {
        public string Name { get; }

        public CompanyCreatedDomainEvent(string name)
        {
            Name = name;
        }
    }
}