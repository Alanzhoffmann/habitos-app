using System.Threading;
using System.Threading.Tasks;

namespace Rotinas.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
