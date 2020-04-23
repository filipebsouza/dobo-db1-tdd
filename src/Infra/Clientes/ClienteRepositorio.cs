using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Clientes.Entidades;
using Domain.Clientes.Dtos;
using Domain.Clientes.Repositorios;
using LiteDB;

namespace Infra.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //C:\\dev\\dobo-db1-tdd\\src\\View.RazorApp
        private readonly string src = Environment.CurrentDirectory.Replace("View.RazorApp", "Infra\\Database\\db.db");

        public List<ClienteDto> Obter()
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
                    })
                    .ToList();
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

        public List<ClienteDto> ObterPorCpf(string cpf)
        {
            try
            {
                using (var db = new LiteDatabase(src))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");

                    var retorno = clientes.Find(x => x.CPF == cpf);

                    if (retorno == null || !retorno.Any()) return null;

                    return retorno.Select(cliente => new ClienteDto
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        SobreNome = cliente.SobreNome,
                        DataDeNascimento = cliente.DataDeNascimento,
                        CPF = cliente.CPF,
                        RG = cliente.RG
                    })
                    .ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}