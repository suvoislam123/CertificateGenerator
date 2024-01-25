using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Employees.View
{
    public class AddOrUpdatEmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
    }
}
