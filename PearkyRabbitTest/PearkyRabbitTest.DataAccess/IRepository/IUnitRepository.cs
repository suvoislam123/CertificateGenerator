using PearkyRabbitTest.DataAccess.IRepository.Account;
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
    }
}
