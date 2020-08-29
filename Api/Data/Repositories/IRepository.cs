using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Reservatio.Models;

namespace Reservatio.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter = null);

        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter = null);

        Task<long> Create(TEntity entity);

        Task<IEnumerable<long>> CreateMany(IList<TEntity> entities);

        Task<TEntity> Update(TEntity entity);

        Task<IEnumerable<TEntity>> UpdateMany(IList<TEntity> entities);

        Task Remove(long id);

        Task Remove(TEntity entity);

        Task RemoveMany(IList<TEntity> entities);

        Task<bool> Exist(Expression<Func<TEntity, bool>> filter = null);
    }
}
