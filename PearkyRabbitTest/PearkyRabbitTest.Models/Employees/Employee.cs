using PearkyRabbitTest.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Employees
{
    public class Employee
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public Guid DepartmentId { get; set; }
       public Department Department { get; set; }
       public string FathersName { get;set; }
       public string MothersName { get;set; }
    }
}
