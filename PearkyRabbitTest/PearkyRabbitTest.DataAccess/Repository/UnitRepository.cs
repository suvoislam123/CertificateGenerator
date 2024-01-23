using PearkyRabbitTest.DataAccess.IRepository;
using PearkyRabbitTest.DataAccess.IRepository.Account;
using PearkyRabbitTest.DataAccess.Repository.Account;
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

        public UnitRepository(ApplicationDbContext db)
        {
            _db = db;
            Users = new UserRepository(_db);
            RefreshToken = new RefreshTokenRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
