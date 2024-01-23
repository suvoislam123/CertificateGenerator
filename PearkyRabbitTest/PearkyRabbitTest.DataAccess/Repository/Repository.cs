using Microsoft.EntityFrameworkCore;
using PearkyRabbitTest.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }
        

        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangesAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => 
            await dbSet.ToListAsync();



        public async Task<T> GetAsync(Guid id) => await
            dbSet.FindAsync(id);
  

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(T entiry)
        {
            dbSet.Remove(entiry);
            return await  _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> RemoveRangeAsync(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            return await _db.SaveChangesAsync() > 0;
        }
        
        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
