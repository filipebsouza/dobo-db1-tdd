using Domain.Clientes.Dto;

namespace Domain.Clientes
{
    public interface IArmazenadorDeCliente
    {
        ClienteDto Armazenar(ClienteDto dto);
    }
}