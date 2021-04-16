using Microsoft.EntityFrameworkCore;
using Rotinas.Domain.Interfaces.Repositories;

namespace Rotinas.Infra.Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Adicionar(object entidade)
        {
            _context.Add(entidade);
        }

        public void Atualizar(object entidade)
        {
            _context.Update(entidade);
        }
    }
}
