using PearkyRabbitTest.DataAccess.Repository;
using PearkyRabbitTest.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.IRepository.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
       
    }
}
