using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rotinas.Domain.Interfaces;

namespace Rotinas.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
