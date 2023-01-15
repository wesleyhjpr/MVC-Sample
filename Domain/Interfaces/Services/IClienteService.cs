
using DevIO.Domain.Models;

namespace DevIO.Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<Cliente, Guid>
    {
        Cliente ObterPorEmail(string email);
    }
}
