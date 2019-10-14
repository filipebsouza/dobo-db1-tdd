using System.Collections.Generic;
using Domain.Clientes.Dto;

namespace Domain.Clientes
{
    public interface IClienteRepositorio
    {
        ClienteDto Incluir(Cliente cliente);
        List<ClienteDto> ObterPorCpf(string cpf);
        List<ClienteDto> Obter();
    }
}