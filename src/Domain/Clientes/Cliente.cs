using System;
using System.Text.RegularExpressions;

namespace Domain.Clientes
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }

        public Cliente(string nome, string sobreNome, DateTime dataDeNascimento, string cpf, string rg)
        {
            ParametrosSaoValidos(nome, sobreNome, dataDeNascimento, cpf, rg);

            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.SobreNome = sobreNome;
            this.DataDeNascimento = dataDeNascimento;
            this.CPF = cpf;
            this.RG = rg;
        }

        private void ParametrosSaoValidos(string nome, string sobreNome, DateTime dataDeNascimento, string cpf, string rg)
        {
            ValidarNome(nome);
            ValidarSobreNome(sobreNome);
            ValidarDataDeNascimento(dataDeNascimento);
            ValidarCpf(cpf);
            ValidarRg(rg);
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome é inválido.");

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é inválido.");
        }

        private void ValidarSobreNome(string sobreNome)
        {
            if (string.IsNullOrEmpty(sobreNome))
                throw new ArgumentException("Sobrenome é inválido.");

            if (string.IsNullOrWhiteSpace(sobreNome))
                throw new ArgumentException("Sobrenome é inválido.");
        }

        private void ValidarDataDeNascimento(DateTime dataDeNascimento)
        {
            if (dataDeNascimento.Date >= DateTime.Now.Date)
                throw new ArgumentException("Data de nascimento deve ser menor que hoje.");
        }

        private void ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("CPF é inválido.");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF é inválido.");

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (!Regex.IsMatch(cpf, @"^\d+$"))
                throw new ArgumentException("CPF é inválido.");

            if (cpf.Length != 11)
                throw new ArgumentException("CPF deve ter 11 caracteres.");
        }

        private void ValidarRg(string rg)
        {
            if (string.IsNullOrEmpty(rg))
                throw new ArgumentException("RG é inválido.");

            if (string.IsNullOrWhiteSpace(rg))
                throw new ArgumentException("RG é inválido.");

            rg = rg.Replace(".", "").Replace("-", "");

            if (!Regex.IsMatch(rg, @"^\d+$"))
                throw new ArgumentException("RG é inválido.");

            if (rg.Length != 9)
                throw new ArgumentException("RG deve ter 9 caracteres.");
        }
    }
}