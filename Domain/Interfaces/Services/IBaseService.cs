namespace DevIO.Domain.Interfaces.Services
{
    public interface IBaseService<TEntidade, TId> : IDisposable where TEntidade : class
    {
        List<TEntidade> ObterTodos();
        TEntidade ObterPorId(TId id);
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TId id);
    }
}
