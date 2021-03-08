using BancoPan.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Entity.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<dynamic> getUser(string cpf);
    }
}
