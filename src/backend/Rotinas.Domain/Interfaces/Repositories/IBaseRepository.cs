namespace Rotinas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        void Adicionar(object entidade);

        void Atualizar(object entidade);
    }
}
