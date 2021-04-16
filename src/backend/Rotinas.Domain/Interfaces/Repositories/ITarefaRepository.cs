using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rotinas.Domain.DTO;

namespace Rotinas.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository
    {
        Task<List<TarefaViewModel>> Buscar(BuscarListaTarefasCommand request, CancellationToken cancellationToken);
    }
}
