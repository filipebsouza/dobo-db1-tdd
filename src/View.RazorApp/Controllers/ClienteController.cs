using Domain.Clientes;
using Domain.Clientes.Dto;
using Microsoft.AspNetCore.Mvc;

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
            var retorno = _armazenadorDeCliente.Armazenar(dto);

            return RedirectToAction("Index");
        }
    }
}