using PearkyRabbitTest.DataAccess.IRepository.Account;
using PearkyRabbitTest.DataAccess.IRepository.Certificates;
using PearkyRabbitTest.DataAccess.IRepository.Departments;
using PearkyRabbitTest.DataAccess.IRepository.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.IRepository
{
    public interface IUnitRepository : IDisposable
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshToken { get; }
        IEmployeeRepository Employee { get; }
        ICertificateRepository Certificate { get; }
        IDepartmentRepository Department { get; }
    }
}
