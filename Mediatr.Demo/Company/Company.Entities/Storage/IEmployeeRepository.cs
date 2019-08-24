namespace Company.Entities.Storage
{
    using System.Collections.Generic;
    
    using System.Threading.Tasks;

    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsyc();
    }
}