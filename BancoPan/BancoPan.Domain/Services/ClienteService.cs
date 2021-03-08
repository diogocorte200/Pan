using AutoMapper;
using BancoPan.Domain.Domain;
using BancoPan.Domain.Domain.Response;
using BancoPan.Domain.Services.Generic;
using BancoPan.Entity.Entity;
using BancoPan.Entity.Repositories.Interfaces;
using BancoPan.Entity.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Domain.Services
{
    public class ClienteService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                              where Tv : ClienteModel
                                              where Te : Cliente
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper,
                             IClienteRepository pessoaRepository, IEnderecoRepository enderecoRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_clienteRepository == null)
                _clienteRepository = pessoaRepository;

            _enderecoRepository = enderecoRepository;
        }


        public async Task<List<ClienteModel>> BuscarCliente(string cpf)
        {
            try
            {
                var clientesAtivas = _clienteRepository.GetAll().Where(x => x.Cpf == cpf);

                List<ClienteModel> clientes = new List<ClienteModel>();
                foreach (var elem in clientesAtivas)
                {
                    var lista = new ClienteModel();
                    lista.Id = elem.Id;
                    lista.Nome = elem.Nome;
                    lista.Cpf = elem.Cpf;

                    clientes.Add(lista);
                }

                return clientes.OrderBy(x => x.Nome).ToList();
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<int> EditarCliente(ClienteEndereco endereco)
        {
            try
            {
                var cliente = _enderecoRepository.GetSingleOrDefault(x => x.IdCliente == endereco.IdCliente);
                if (cliente != null)
                {
                    cliente.Logradouro = endereco.Logradouro;
                    cliente.Numero = endereco.Numero;
                    cliente.Complemento = endereco.Complemento;
                    cliente.Cidade = endereco.Cidade;
                    cliente.Estado = endereco.Estado;
                    cliente.Pais = endereco.Pais;
                    cliente.Cep = endereco.Cep;
                }

                _enderecoRepository.Update(cliente);
                _enderecoRepository.Save();

                return cliente.IdEndereco;
            }
            catch (EntityException entError)
            {
                throw new Exception(entError.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
