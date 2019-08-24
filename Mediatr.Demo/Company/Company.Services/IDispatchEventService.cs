using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IDispatchEventService
    {
        Task DispatchDomainEventsAsync(IEnumerable<INotification> notificationEvents);
    }
}
