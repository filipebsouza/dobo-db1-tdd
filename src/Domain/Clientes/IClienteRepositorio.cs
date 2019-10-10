using System.Collections.Generic;
using Domain.Clientes.Dto;

namespace Domain.Clientes
{
    public interface IClienteRepositorio
    {
        ClienteDto Incluir(Cliente cliente);
        IEnumerable<ClienteDto> ObterPorCpf(string cpf);
        IEnumerable<ClienteDto> Obter();
    }
}