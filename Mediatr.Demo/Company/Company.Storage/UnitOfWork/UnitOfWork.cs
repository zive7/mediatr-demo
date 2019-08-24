namespace Company.Storage.UnitOfWork
{
    using Company.Entities.UnitOfWork;
    using Company.Storage.Database.Context;
    using Company.Storage.Entities;
    using MediatR;
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContext _context;
        private readonly IMediator _mediator;

        private readonly System.Data.Entity.EntityState[] _trackedStates = new[]
        {
            System.Data.Entity.EntityState.Added,
            System.Data.Entity.EntityState.Deleted,
            System.Data.Entity.EntityState.Modified
        };

        public UnitOfWork(IDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();

                await DispatchDomainEventsAsync();

                return result;
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    sb.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    sb.Append(Environment.NewLine);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        sb.Append(Environment.NewLine);
                    }
                }
                string errorMessage = sb.ToString();
                throw new DbEntityValidationException(errorMessage, e);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = _context.ChangeTracker.Entries<BaseEntity>().Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
            domainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}