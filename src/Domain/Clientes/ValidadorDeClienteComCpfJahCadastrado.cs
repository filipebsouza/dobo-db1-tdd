using System;
using System.Linq;

namespace Domain.Clientes
{
    public class ValidadorDeClienteComCpfJahCadastrado : IValidadorDeClienteComCpfJahCadastrado
    {
        private IClienteRepositorio _clienteRepositorio;

        public ValidadorDeClienteComCpfJahCadastrado(IClienteRepositorio clienteRepositorio)
        {
            this._clienteRepositorio = clienteRepositorio;
        }

        public void Validar(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF é inválido.");

            var clientesComMesmoCpf = _clienteRepositorio.ObterPorCpf(cpf);

            if (clientesComMesmoCpf?.FirstOrDefault() != null)
                throw new ArgumentException("Já existe cliente com este CPF.");
        }
    }
}