using Domain.Clientes.Dto;

namespace Domain.Clientes
{
    public interface IArmazenadorDeCliente
    {
        Cliente Armazenar(ClienteDto dto);
    }
}