using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //Task<List<TEntity>> Filtered(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity> GetOne(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
        //Task<int> CreateRange(List<TEntity> entities, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        //Task<int> UpdteRange(List<TEntity> entities, CancellationToken cancellationToken);
        Task<bool> Delete(TEntity entity, CancellationToken cancellationToken);
    }
}
