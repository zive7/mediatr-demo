namespace Company.Entities.UnitOfWork
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}