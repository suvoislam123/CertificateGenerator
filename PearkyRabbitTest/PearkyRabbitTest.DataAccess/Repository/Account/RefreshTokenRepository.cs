using Microsoft.EntityFrameworkCore;
using PearkyRabbitTest.DataAccess.IRepository.Account;
using PearkyRabbitTest.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.Repository.Account
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _db;

        public RefreshTokenRepository(ApplicationDbContext db) : base(db) => _db = db;

        public RefreshToken GetRefreshTokenByToken(string token) => _db.RefreshToken.Where(x => x.Token == token).Include(x => x.ApplicationUser).FirstOrDefault();

        public List<RefreshToken> GetRefreshTokenByUserId(string Id) => _db.RefreshToken.Where(x => x.ApplicationUserId == Id).ToList();
    }
}
