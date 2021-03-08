using BancoPan.Entity.Context;
using BancoPan.Entity.Entity;
using BancoPan.Entity.Entity.Model;
using BancoPan.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Entity.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private ClienteContext _appContext => (ClienteContext)_context;

        public ClienteRepository(ClienteContext context) : base(context)
        { }

        public async Task<IEnumerable<Usuario>> getUser(string cpf)
        {
            var idCliente = _context.clientes.FirstOrDefault(x => x.Cpf == cpf);

            var lista = new Usuario();

            var result = new List<Usuario>();

            var query = from m in _appContext.enderecos
                        join g in _appContext.clientes on m.IdCliente equals idCliente.Id
                        select new { m, g };

            foreach (var item in query)
            {
                lista.Id = item.g.Id;
                lista.Nome = item.g.Nome;
                lista.Numero = item.m.Numero;
                lista.Complemento = item.m.Complemento;
                lista.Logradouro = item.m.Logradouro;
                lista.Cpf = item.g.Cpf;
                lista.Cidade = item.m.Cidade;
                lista.Cep = item.m.Cep;
                lista.Estado = item.m.Estado;
                lista.Pais = item.m.Pais;
            }

            result.Add(lista);
            return result.OrderBy(x => x.Nome);
        }
    }
}
