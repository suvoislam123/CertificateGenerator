using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> RemoveAsync(T entiry);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveRangeAsync(IEnumerable<T> entity);
        Task<bool> AddRangesAsync(IEnumerable<T> entities);

    }
}
