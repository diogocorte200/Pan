using BancoPan.Entity.Entity;
using BancoPan.Entity.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Entity.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Usuario>> getUser(string cpf);
    }
}
