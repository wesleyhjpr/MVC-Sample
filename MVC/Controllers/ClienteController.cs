using DevIO.Domain.Interfaces;
using DevIO.Domain.Interfaces.Services;
using DevIO.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.MVC.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService, 
                                INotificador notificador) : base(notificador)
        {
            _clienteService = clienteService;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            List<Cliente> clientes = _clienteService.ObterTodos();

            return View(clientes);
        }

        // GET: ClienteController/Details/146EC022-4705-42CD-8C08-E484EBF0A842
        public ActionResult Details(Guid id)
        {
            Cliente cliente = _clienteService.ObterPorId(id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);

            _clienteService.Adicionar(cliente);

            if (!OperacaoValida()) return View(cliente);

            return RedirectToAction("Index");
        }

        // GET: ClienteController/Edit/146EC022-4705-42CD-8C08-E484EBF0A842
        public ActionResult Edit(Guid id)
        {
            Cliente cliente = _clienteService.ObterPorId(id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: ClienteController/Edit/146EC022-4705-42CD-8C08-E484EBF0A842
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();

            if (!ModelState.IsValid) return View(cliente);

            _clienteService.Atualizar(cliente);

            if (!OperacaoValida()) return View(cliente);

            return RedirectToAction("Index");
        }

        // GET: ClienteController/Delete/146EC022-4705-42CD-8C08-E484EBF0A842
        public ActionResult Delete(Guid id)
        {
            Cliente cliente = _clienteService.ObterPorId(id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: ClienteController/Delete/146EC022-4705-42CD-8C08-E484EBF0A842
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();

            Cliente clienteDB = _clienteService.ObterPorId(id);

            if (clienteDB == null) return NotFound();

            _clienteService.Remover(id);

            if (!OperacaoValida()) return View(cliente);

            TempData["Sucesso"] = "Cliente excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
