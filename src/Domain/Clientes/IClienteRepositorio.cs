using System.Collections.Generic;

namespace Domain.Clientes
{
    public interface IClienteRepositorio
    {
        Cliente Incluir(Cliente cliente);
        IEnumerable<Cliente> ObterPorCpf(string cpf);
    }
}