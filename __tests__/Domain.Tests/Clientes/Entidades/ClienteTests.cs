using System;
using Domain.Clientes.Entidades;
using Xunit;

namespace Domain.Tests.Clientes.Entidades
{
    public class ClienteTests
    {
        // * Tarefa 01
        // User Story : Eu como usuário do sistema preciso cadastrar cliente com seus dados incluindo nome, telefone, etc.
        // Caso de teste 01 : Criar domínio Cliente.

        public ClienteTests() { }

        [Fact]
        public void DeveCriarCliente()
        {
            var clienteEsperado = new
            {
                Nome = "João",
                SobreNome = "Souza",
                DataDeNascimento = new DateTime(2000, 01, 01),
                CPF = "03227666699",
                RG = "001112789"
            };

            var cliente = new Cliente(clienteEsperado.Nome, clienteEsperado.SobreNome, clienteEsperado.DataDeNascimento, clienteEsperado.CPF, clienteEsperado.RG);

            Assert.True(cliente.Nome == clienteEsperado.Nome);
            Assert.True(cliente.SobreNome == clienteEsperado.SobreNome);
            Assert.True(cliente.DataDeNascimento == clienteEsperado.DataDeNascimento);
            Assert.True(cliente.CPF == clienteEsperado.CPF);
            Assert.True(cliente.RG == clienteEsperado.RG);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        public void NaoDeveCriarClienteComNomeInvalido(string nomeInvalido)
        {
            var erroEsperado = "Nome é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente(nomeInvalido, "SobreNome", new DateTime(2000, 01, 01), "03227666699", "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        public void NaoDeveCriarClienteComSobrenNomeInvalido(string sobreNomeInvalido)
        {
            var erroEsperado = "Sobrenome é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("João", sobreNomeInvalido, new DateTime(2000, 01, 01), "03227666699", "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Fact]
        public void NaoDeveCriarClienteComDataDeNascimentoMaiorOuIgualAhHoje()
        {
            var dataDeNascimentoInvalida = DateTime.Now;
            var erroEsperado = "Data de nascimento deve ser menor que hoje.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("Nome", "SobreNome", dataDeNascimentoInvalida, "02245656789", "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        public void NaoDeveCriarClienteComCpfInvalido(string cpfInvalido)
        {
            var erroEsperado = "CPF é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("João", "Souza", new DateTime(2000, 01, 01), cpfInvalido, "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("12345677722")]
        [InlineData("21239879898")]
        [InlineData("19287389127")]
        public void DeveCriarClienteComCpfQueContenhaSomenteNumeros(string cpf)
        {
            var cliente = new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), cpf, "001111111");

            Assert.True(cliente.CPF == cpf);
        }

        [Theory]
        [InlineData("asdasdadasd")]
        [InlineData("asdHGgas668")]
        [InlineData("99)))2^^´´]")]
        public void NaoDeveCriarClienteComCpfQueContenhaCaracteresQueNaoSejamNumeros(string cpfIncorreto)
        {
            var erroEsperado = "CPF é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), cpfIncorreto, "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("11111111111111111")]
        [InlineData("11")]
        public void NaoDeveCriarClienteComCpfQueTenhaQuantidadeDeCaracteresDiferenteDeOnze(string cpfComTamanhoIncorreto)
        {
            var erroEsperado = "CPF deve ter 11 caracteres.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), cpfComTamanhoIncorreto, "001111111")
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("          ")]
        public void NaoDeveCriarClienteComRgInvalido(string rgInvalido)
        {
            var erroEsperado = "RG é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("João", "Souza", new DateTime(2000, 01, 01), "02335676544", rgInvalido)
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("001980098")]
        [InlineData("227766559")]
        [InlineData("009977655")]
        public void DeveCriarClienteComRgQueContenhaSomenteNumeros(string rg)
        {
            var cliente = new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), "03224567888", rg);

            Assert.True(cliente.RG == rg);
        }

        [Theory]
        [InlineData("asdasdadg")]
        [InlineData("asdHG668r")]
        [InlineData("9)2^^´´]")]
        public void NaoDeveCriarClienteComRgQueContenhaCaracteresQueNaoSejamNumeros(string rgIncorreto)
        {
            var erroEsperado = "RG é inválido.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), "03224567888", rgIncorreto)
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

        [Theory]
        [InlineData("11111111111111111")]
        [InlineData("11")]
        public void NaoDeveCriarClienteComRgQueTenhaQuantidadeDeCaracteresDiferenteDeNove(string rgComTamanhoIncorreto)
        {
            var erroEsperado = "RG deve ter 9 caracteres.";

            var exception = Assert.Throws<ArgumentException>(
                () => new Cliente("Nome", "SobreNome", new DateTime(2000, 01, 01), "03224567888", rgComTamanhoIncorreto)
            );

            Assert.Equal(erroEsperado, exception.Message);
        }

    }
}

