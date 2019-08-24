using Company.Entities.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Services.DomainEventHandlers
{
    public class CompanyCreatedDomainEventhandler : INotificationHandler<CompanyCreatedDomainEvent>
    {
        public CompanyCreatedDomainEventhandler()
        {

        }

        public Task Handle(CompanyCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
