using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Entities.Storage
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsyc();
    }
}
