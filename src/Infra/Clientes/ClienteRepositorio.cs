using System.Collections.Generic;
using System.Linq;
using Domain.Clientes;
using Domain.Clientes.Dto;
using LiteDB;

namespace Infra.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly string src = "/mnt/d/dev/dojo-db1/src/Infra/Database/db.db";

        public IEnumerable<ClienteDto> Obter()
        {
            try
            {
                using (var db = new LiteDatabase(src))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");

                    var retorno = clientes.FindAll();

                    if (retorno == null || !retorno.Any()) return null;

                    return retorno.Select(cliente => new ClienteDto
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        SobreNome = cliente.SobreNome,
                        DataDeNascimento = cliente.DataDeNascimento,
                        CPF = cliente.CPF,
                        RG = cliente.RG
                    });
                }
            }
            catch
            {
                return null;
            }
        }

        public ClienteDto Incluir(Cliente cliente)
        {
            try
            {
                using (var db = new LiteDatabase(src))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");
                    clientes.Insert(cliente);

                    return new ClienteDto
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        SobreNome = cliente.SobreNome,
                        DataDeNascimento = cliente.DataDeNascimento,
                        CPF = cliente.CPF,
                        RG = cliente.RG
                    };
                }
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ClienteDto> ObterPorCpf(string cpf)
        {
            try
            {
                using (var db = new LiteDatabase(src))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");

                    return clientes.Find(x => x.CPF == cpf).Select(cliente => new ClienteDto
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        SobreNome = cliente.SobreNome,
                        DataDeNascimento = cliente.DataDeNascimento,
                        CPF = cliente.CPF,
                        RG = cliente.RG
                    });
                }
            }
            catch
            {
                return null;
            }
        }
    }
}