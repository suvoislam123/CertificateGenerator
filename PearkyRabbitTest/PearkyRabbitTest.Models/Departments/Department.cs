﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PearkyRabbitTest.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Departments
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
