using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.IService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
