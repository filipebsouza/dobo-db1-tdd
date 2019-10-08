using System.Collections.Generic;
using Domain.Clientes;
using Domain.Clientes.Dto;
using LiteDB;

namespace Infra.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Cliente Incluir(Cliente cliente)
        {
            try
            {
                using (var db = new LiteDatabase(@"~/src/Infra/Database/db.db"))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");
                    clientes.Insert(cliente);

                    return cliente;
                }
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Cliente> ObterPorCpf(string cpf)
        {
            try
            {
                using (var db = new LiteDatabase(@"~/src/Infra/Database/db.db"))
                {
                    var clientes = db.GetCollection<Cliente>("clientes");

                    return clientes.Find(x => x.CPF == cpf);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}