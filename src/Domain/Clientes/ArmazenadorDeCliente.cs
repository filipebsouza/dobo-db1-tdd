using Domain.Clientes.Dto;

namespace Domain.Clientes
{
    public class ArmazenadorDeCliente : IArmazenadorDeCliente
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidadorDeClienteComCpfJahCadastrado _validadorDeClienteComCpfJahCadastrado;

        public ArmazenadorDeCliente(
            IClienteRepositorio clienteRepositorio,
            IValidadorDeClienteComCpfJahCadastrado validadorDeClienteComCpfJahCadastrado
        )
        {
            this._clienteRepositorio = clienteRepositorio;
            this._validadorDeClienteComCpfJahCadastrado = validadorDeClienteComCpfJahCadastrado;
        }

        public ClienteDto Armazenar(ClienteDto dto)
        {
            var cliente = new Cliente(
                dto.Nome,
                dto.SobreNome,
                dto.DataDeNascimento,
                dto.CPF,
                dto.RG
            );

            _validadorDeClienteComCpfJahCadastrado.Validar(cliente.CPF);

            return _clienteRepositorio.Incluir(cliente);
        }
    }
}
