using DevIO.Domain.Interfaces;
using DevIO.Domain.Interfaces.Repositories;
using DevIO.Domain.Interfaces.Services;
using DevIO.Domain.Models;

namespace DevIO.Domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(INotificador notificador, 
                            IClienteRepository clienteRepository) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ObterTodos()
        {
           return _clienteRepository.ObterTodos();
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public void Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(cliente)) return;

            if(_clienteRepository.Adicionar(cliente) == 0) NotificarErroAdicionar();
        }

        public void Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(cliente)) return;

            if (_clienteRepository.Atualizar(cliente) == 0) NotificarErroAtualizar();
        }

        public void Remover(Guid id)
        {
            if(_clienteRepository.Remover(id) == 0) NotificarErroRemover(); ;
        }

        public void Dispose() => _clienteRepository.Dispose();
    }
}
