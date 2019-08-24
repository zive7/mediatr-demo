namespace Company.Services.DomainEventHandlers
{
    using Company.Entities.DomainEvents;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CompanyCreatedDomainEventhandler : INotificationHandler<CompanyCreatedDomainEvent>
    {
        public CompanyCreatedDomainEventhandler()
        {

        }

        public Task Handle(CompanyCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: your code goes here

            return Task.CompletedTask;
        }
    }
}
