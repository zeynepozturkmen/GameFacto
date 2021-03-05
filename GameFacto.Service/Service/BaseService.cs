using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.Service
{

    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly GameFactoDbContext _db;
        private readonly DbSet<T> _dbSet;

        public BaseService(GameFactoDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.AsQueryable().Where(q => q.Id == id && !q.IsDeleted).FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _db.SaveChanges();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public T Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;

            _db.SaveChanges();

            return entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

    }


}
