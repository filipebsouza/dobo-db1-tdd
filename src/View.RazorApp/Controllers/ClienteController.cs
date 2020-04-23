using Domain.Clientes;
using Domain.Clientes.Dtos;
using Domain.Clientes.Interfaces;
using Domain.Clientes.Repositorios;
using Microsoft.AspNetCore.Mvc;
using View.RazorApp.ViewModels;

namespace View.RazorApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IArmazenadorDeCliente _armazenadorDeCliente;

        public ClienteController(IClienteRepositorio clienteRepositorio, IArmazenadorDeCliente armazenadorDeCliente)
        {
            _clienteRepositorio = clienteRepositorio;
            _armazenadorDeCliente = armazenadorDeCliente;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Pages/Clientes/Index.cshtml", _clienteRepositorio.Obter());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View("Pages/Clientes/Incluir.cshtml", new ClienteDto());
        }

        [HttpPost]
        public ActionResult Incluir(ClienteDto dto)
        {
            try
            {
                _armazenadorDeCliente.Armazenar(dto);

                return RedirectToAction("Index");
            }
            catch (System.ArgumentException ex)
            {
                PreencherMensagensDeValidacao(ex);

                return View("Pages/Clientes/Incluir.cshtml", dto);
            }
        }

        private void PreencherMensagensDeValidacao(System.ArgumentException exception)
        {
            var validationMessage = new ValidationMessage
            {
                Mensagem = exception.Message
            };

            ViewBag.ValidationMessage = validationMessage;
        }
    }
}