using PearkyRabbitTest.DataAccess.IRepository.Certificates;
using PearkyRabbitTest.Models.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.Repository.Certificates
{
    public class CertificateRepository : Repository<Certificate>, ICertificateRepository
    {
        private readonly ApplicationDbContext _db;
        public CertificateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
