﻿using DevIO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            var temNotificacao = _notificador.TemNotificacao();

            if (temNotificacao)
            {
                var notificacoes = _notificador.ObterNotificacoes();
                notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));
            }

            return !temNotificacao;
        }
    }
}
