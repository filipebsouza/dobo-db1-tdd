using System;
using Bogus;
using Bogus.Extensions.Brazil;
using Domain.Clientes;
using Domain.Clientes.Dto;
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
        private readonly Mock<IValidadorDeClienteComCpfJahCadastrado> _validadorDeClienteComCpfJahCadastradoMock;
        private readonly ArmazenadorDeCliente _armazenadorDeCliente;

        public ArmazenadorDeClienteTests()
        {
            _faker = new Faker();
            _clienteRepositorioMock = new Mock<IClienteRepositorio>();
            _validadorDeClienteComCpfJahCadastradoMock = new Mock<IValidadorDeClienteComCpfJahCadastrado>();

            _armazenadorDeCliente = new ArmazenadorDeCliente(
                _clienteRepositorioMock.Object,
                _validadorDeClienteComCpfJahCadastradoMock.Object
            );
        }

        private ClienteDto CriarCenarioParaDeveArmazenarCliente()
        {
            var dto = new ClienteDto
            {
                Nome = _faker.Name.FirstName(),
                SobreNome = _faker.Name.LastName(),
                DataDeNascimento = _faker.Date.Past(18),
                CPF = _faker.Person.Cpf(),
                RG = "222444555"
            };

            var clienteEsperado = new Cliente(
                dto.Nome,
                dto.SobreNome,
                dto.DataDeNascimento,
                dto.CPF,
                dto.RG
            );

            _clienteRepositorioMock.Setup(r => r.Incluir(It.IsAny<Cliente>())).Returns(clienteEsperado);

            return dto;
        }

        private ClienteDto CriarCenarioParaNaoDeveArmazenarClienteSeAlgumDadoDoDominioForInvalido()
        {
            string sobreNomeInvalido = null;

            return new ClienteDto
            {
                Nome = _faker.Name.FirstName(),
                SobreNome = sobreNomeInvalido,
                DataDeNascimento = _faker.Date.Past(18),
                CPF = _faker.Person.Cpf(),
                RG = "222444555"
            };
        }

        [Fact]
        public void DeveArmazenarCliente()
        {
            var dto = CriarCenarioParaDeveArmazenarCliente();

            var clienteSalvo = _armazenadorDeCliente.Armazenar(dto);

            Assert.NotNull(clienteSalvo);
        }

        [Fact]
        public void NaoDeveArmazenarClienteSeAlgumDadoDoDominioForInvalido()
        {
            var dto = CriarCenarioParaNaoDeveArmazenarClienteSeAlgumDadoDoDominioForInvalido();
            var erroEsperado = "Sobrenome é inválido.";

            var exception = Assert.Throws<ArgumentException>(() => _armazenadorDeCliente.Armazenar(dto));

            Assert.Equal(exception.Message, erroEsperado);
        }
    }
}