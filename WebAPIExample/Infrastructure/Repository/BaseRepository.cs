using Domain.Infrastructure.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context;
        public BaseRepository(AppDBContext alarmsContext)
        {
            _context = alarmsContext;
        }
        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {

            var createdEntity = _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return createdEntity.Entity;
        }

        public async Task<bool> Delete(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<TEntity> GetOne(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            var modifyEntity = _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return modifyEntity.Entity;
        }
    }
}
