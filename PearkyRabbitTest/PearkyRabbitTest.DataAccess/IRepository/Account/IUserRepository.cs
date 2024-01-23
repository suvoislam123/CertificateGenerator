using PearkyRabbitTest.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.IRepository.Account
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        public bool IfUserEmailAlreadyExists(Guid id, string eamil);
        public bool IfUserNameAlreadyExists(Guid id, string username);
    }
}
