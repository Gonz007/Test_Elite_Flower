using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Infraestructure.Repository
{
    public class ApplicationDbContextUnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public ApplicationDbContextUnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        void IDisposable.Dispose()
        {
            Context.Dispose();
        }

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        void IUnitOfWork.CommitTransaction()
        {
            Context.SaveChanges();
        }
    }
}
