using BancoPan.Entity.Context;
using BancoPan.Entity.Entity;
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

        public async Task<dynamic> getUser(string cpf)
        {
            var idCliente = _context.clientes.FirstOrDefault(x => x.Cpf == cpf);

            var result = from m in _appContext.enderecos
                         join g in _appContext.clientes on m.IdCliente equals idCliente.Id
                         select new { m, g };

            return result.ToList();

        }
    }
}
