using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions.Brazil;
using Domain.Clientes;
using Moq;
using Xunit;

namespace Domain.Tests.Clientes
{
    public class ValidadorDeClienteComCpfJahCadastradoTests
    {
        // * Tarefa 01
        // User Story : Eu como usuário do sistema preciso cadastrar cliente com seus dados incluindo nome, telefone, etc.
        // Caso de teste 03: Validar no armazenador do Cliente se nome já foi informado e se CPF já foi informado.

        private readonly Faker _faker;
        private readonly Mock<IClienteRepositorio> _clienteRepositorioMock;
        private readonly ValidadorDeClienteComCpfJahCadastrado _validadorDeClienteComCpfJahCadastrado;

        public ValidadorDeClienteComCpfJahCadastradoTests()
        {
            _faker = new Faker();
            _clienteRepositorioMock = new Mock<IClienteRepositorio>();
            _validadorDeClienteComCpfJahCadastrado = new ValidadorDeClienteComCpfJahCadastrado(
                _clienteRepositorioMock.Object
            );
        }

        private string CriarCenarioParaDeveValidarClienteQuePossuiMesmoCpf()
        {
            var clienteComCpfJahExistente = new Cliente(
                _faker.Name.FirstName(),
                _faker.Name.LastName(),
                _faker.Date.Past(18),
                _faker.Person.Cpf(),
                "222444555"
            );

            _clienteRepositorioMock.Setup(r => r.ObterPorCpf(clienteComCpfJahExistente.CPF))
                .Returns(new List<Cliente> { clienteComCpfJahExistente }.AsEnumerable());

            return clienteComCpfJahExistente.CPF;
        }

        [Fact]
        public void NaoDeveValidarClienteQuePossuiMesmoCpfQuandoCpfInformadoForInvalido()
        {
            string cpf = null;
            var erroEsperado = "CPF é inválido.";

            var exception = Assert.Throws<ArgumentException>(() => _validadorDeClienteComCpfJahCadastrado.Validar(cpf));

            Assert.Equal(exception.Message, erroEsperado);
        }

        [Fact]
        public void DeveValidarClienteQuePossuiMesmoCpf()
        {
            var cpfJahInformado = CriarCenarioParaDeveValidarClienteQuePossuiMesmoCpf();
            var erroEsperado = "Já existe cliente com este CPF.";

            var exception = Assert.Throws<ArgumentException>(() => _validadorDeClienteComCpfJahCadastrado.Validar(cpfJahInformado));

            Assert.Equal(exception.Message, erroEsperado);
        }

        [Fact]
        public void NaoDeveValidarClienteQuePossuiMesmoCpfPoisCpfInformadoEhNovo()
        {
            var cpf = _faker.Person.Cpf();

            _validadorDeClienteComCpfJahCadastrado.Validar(cpf);

            _clienteRepositorioMock.Verify(v => v.ObterPorCpf(cpf));
        }
    }
}