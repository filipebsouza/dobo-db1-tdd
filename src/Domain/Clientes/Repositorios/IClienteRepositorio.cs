using System.Collections.Generic;
using Domain.Clientes.Dtos;
using Domain.Clientes.Entidades;

namespace Domain.Clientes.Repositorios
{
    public interface IClienteRepositorio
    {
        ClienteDto Incluir(Cliente cliente);
        List<ClienteDto> ObterPorCpf(string cpf);
        List<ClienteDto> Obter();
    }
}