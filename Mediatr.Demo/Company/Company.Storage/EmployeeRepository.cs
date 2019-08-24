using Company.Entities;
using Company.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Storage
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public Task<List<Employee>> GetEmployeesAsyc()
        {
            throw new NotImplementedException();
        }
    }
}
