using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestEliteFlower.Domain.Interfaces
{
    public interface IRepository<T> : IQueryable<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        IEnumerable<T> GetAll();
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      string includeProperties = "");

        Task SaveChangesAsync();
    }
}
