using PearkyRabbitTest.DataAccess.IRepository;
using PearkyRabbitTest.DataAccess.IRepository.Account;
using PearkyRabbitTest.DataAccess.IRepository.Certificates;
using PearkyRabbitTest.DataAccess.IRepository.Departments;
using PearkyRabbitTest.DataAccess.IRepository.Employees;
using PearkyRabbitTest.DataAccess.Repository.Account;
using PearkyRabbitTest.DataAccess.Repository.Certificates;
using PearkyRabbitTest.DataAccess.Repository.Departments;
using PearkyRabbitTest.DataAccess.Repository.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _db;
        public IUserRepository Users { get; private set; }

        public IRefreshTokenRepository RefreshToken { get; private set; }

        public IEmployeeRepository Employee { get; private set; }

        public ICertificateRepository Certificate { get; private set; } 

        public IDepartmentRepository Department { get; private set; }

        public UnitRepository(ApplicationDbContext db)
        {
            _db = db;
            Users = new UserRepository(_db);
            RefreshToken = new RefreshTokenRepository(_db);
            Certificate = new CertificateRepository(_db);
            Employee = new EmployeeRepository(_db);
            Department = new DepartmentRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
