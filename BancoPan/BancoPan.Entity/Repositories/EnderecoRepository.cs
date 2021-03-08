using BancoPan.Entity.Context;
using BancoPan.Entity.Entity;
using BancoPan.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoPan.Entity.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        private ClienteContext _appContext => (ClienteContext)_context;

        public EnderecoRepository(ClienteContext context) : base(context)
        { }
    }
}
