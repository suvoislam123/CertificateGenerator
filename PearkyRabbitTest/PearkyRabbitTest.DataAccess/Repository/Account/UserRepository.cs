using PearkyRabbitTest.DataAccess.IRepository;
using PearkyRabbitTest.DataAccess.IRepository.Account;
using PearkyRabbitTest.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.Repository.Account
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool IfUserEmailAlreadyExists(Guid id, string eamil) => (id == Guid.Empty) ?
            _db.Users.Where(x => x.Email.Trim() == eamil.Trim())
            .FirstOrDefault() != null :
            _db.Users.Where(x => x.Email.Trim() == eamil.Trim() && x.Id != id.ToString())
            .FirstOrDefault() != null;

        public bool IfUserNameAlreadyExists(Guid id, string username) => (id == Guid.Empty) ?
            _db.Users.Where(x => x.UserName.Trim() == username.Trim())
            .FirstOrDefault() != null :
            _db.Users.Where(x => x.UserName.Trim() == username.Trim() && x.Id != id.ToString())
            .FirstOrDefault() != null;

    }
}
