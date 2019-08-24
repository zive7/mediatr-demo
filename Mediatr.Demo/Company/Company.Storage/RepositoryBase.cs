
namespace Company.Storage
{
    using Company.Entities;
    using Company.Storage.Database.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class RepositoryBase
    {
        protected readonly IDbContext _context;

        protected RepositoryBase(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns querable set of no tracked T filtered by DeletedOn
        /// </summary>
        protected IQueryable<T> All<T>() where T : BaseEntity
        {
            return _context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Attach or update storage entity
        /// </summary>
        protected void AttachOrUpdate(object entity, System.Data.Entity.EntityState state)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)}", "Provided storage entity is null.");
            }

            ObjectContext context = ((IObjectContextAdapter)_context).ObjectContext;
            EntityKey key = context.CreateEntityKey(PluralEntity(entity), entity);

            if (context.ObjectStateManager.TryGetObjectStateEntry(key, out ObjectStateEntry entry))
            {
                entry.ApplyCurrentValues(entity);
            }
            else
            {
                _context.Entry(entity).State = state;
            }
        }

        /// <summary>
        /// Returns pluralized name from storage entity
        /// </summary>
        protected string PluralEntity(object entityName)
        {
            return _context.GetType()
                           .GetProperties()
                           .FirstOrDefault(p => p.PropertyType.ToString().EndsWith(entityName.ToString().Split('.').Last() + ']'))?.Name;
        }
    }
}
