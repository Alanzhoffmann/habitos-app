using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rotinas.Domain.DTO;
using Rotinas.Domain.Entidades;
using Rotinas.Domain.Interfaces.Repositories;

namespace Rotinas.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly RotinasContext _context;

        public TarefaRepository(IBaseRepository baseRepository, RotinasContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }

        public void Adicionar(object entidade) => _baseRepository.Adicionar(entidade);

        public void Atualizar(object entidade) => _baseRepository.Atualizar(entidade);

        public Task<List<TarefaViewModel>> Buscar(BuscarListaTarefasCommand request, CancellationToken cancellationToken)
        {
            return _context.Set<Tarefa>()
                .Select(t => new TarefaViewModel(
                    t.Id.ToString(),
                    t.Repeticao != null ? (RepeticaoViewModel)t.Repeticao : null,
                    t.IntervaloPossivel != null ? (IntervaloViewModel)t.IntervaloPossivel : null))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
