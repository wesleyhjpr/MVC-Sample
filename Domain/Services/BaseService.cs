using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using DevIO.Domain.Notificacoes;
using FluentValidation.Results;

namespace DevIO.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (ValidationFailure error in validationResult.Errors)
                Notificar(error.ErrorMessage);
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TE>(TE entidade) where TE : Validacao
        {
            ValidationResult validador = entidade.Validar();

            if (validador.IsValid) return true;

            Notificar(validador);

            return false;
        }

        protected void NotificarErroAdicionar() => Notificar("Não foi possível inserir registro no banco.");
        protected void NotificarErroAtualizar() => Notificar("Não foi possível atualizar registro no banco.");
        protected void NotificarErroRemover() => Notificar("Não foi possível remover registro do banco.");
    }
}
