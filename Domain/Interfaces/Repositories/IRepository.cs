using DevIO.Domain.Models;

namespace DevIO.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);
        List<TEntity> ObterTodos();
        int Adicionar(TEntity entity);
        int Atualizar(TEntity entity);
        int Remover(Guid id);
    }
}
