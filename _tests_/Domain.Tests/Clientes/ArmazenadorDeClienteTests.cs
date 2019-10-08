using System;
using Bogus;
using Bogus.Extensions.Brazil;
using Domain.Clientes;
using Moq;
using Xunit;

namespace Domain.Tests.Clientes
{
    public class ArmazenadorDeClienteTests
    {
        // * Tarefa 01
        // User Story : Eu como usuário do sistema preciso cadastrar cliente com seus dados incluindo nome, telefone, etc.
        // Caso de teste 02: Criar armazenador de Cliente.

        private readonly Faker _faker;
        private readonly Mock<IClienteRepositorio> _clienteRepositorioMock;
        private readonly ArmazenadorDeCliente _armazenadorDeCliente;

        public ArmazenadorDeClienteTests()
        {
            _faker = new Faker();
            _clienteRepositorioMock = new Mock<IClienteRepositorio>();

            _armazenadorDeCliente = new ArmazenadorDeCliente(
                _clienteRepositorioMock.Object
            );
        }

        private Cliente CriarCenarioParaDeveArmazenarCliente()
        {
            return new Cliente(
                _faker.Name.FirstName(),
                _faker.Name.LastName(),
                _faker.Date.Past(18),
                _faker.Person.Cpf(),
                "222444555"
            );
        }

        [Fact]
        public void DeveArmazenarCliente()
        {
            var cliente = CriarCenarioParaDeveArmazenarCliente();

            _armazenadorDeCliente.Armazenar(cliente);

            Assert.NotNull(cliente.Id);
        }
    }

    internal class ArmazenadorDeCliente
    {
        private IClienteRepositorio _clienteRepositorio;

        public ArmazenadorDeCliente(IClienteRepositorio clienteRepositorio)
        {
            this._clienteRepositorio = clienteRepositorio;
        }

        internal void Armazenar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}