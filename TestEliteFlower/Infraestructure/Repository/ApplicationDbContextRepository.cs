using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Infraestructure.Repository
{
    public class ApplicationDbContextRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ApplicationDbContextRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dbSet.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => _dbSet.AsQueryable().ElementType;

        public Expression Expression => _dbSet.AsQueryable().Expression;

        public IQueryProvider Provider => _dbSet.AsQueryable().Provider;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
