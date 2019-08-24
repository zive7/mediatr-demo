using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public class DispatchEventService : IDispatchEventService
    {
        private readonly IMediator _mediator;
        public DispatchEventService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchDomainEventsAsync(IEnumerable<INotification> notificationEvents)
        {
            var tasks = notificationEvents
               .Select(async (domainEvent) => {
                   await _mediator.Publish(domainEvent);
               });

            await Task.WhenAll(tasks);
        }
    }
}
