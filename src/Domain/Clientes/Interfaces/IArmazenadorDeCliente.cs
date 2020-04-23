using Domain.Clientes.Dtos;

namespace Domain.Clientes.Interfaces
{
    public interface IArmazenadorDeCliente
    {
        ClienteDto Armazenar(ClienteDto dto);
    }
}