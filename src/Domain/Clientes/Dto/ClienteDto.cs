using System;

namespace Domain.Clientes.Dto
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    }
}