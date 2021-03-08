using BancoPan.Domain.Domain;
using BancoPan.Domain.Services;
using BancoPan.Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BancoPan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService<ClienteModel, Cliente> _cliente;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ClienteService<ClienteModel, Cliente> pessoaService, ILogger<ClienteController> logger)
        {
            _cliente = pessoaService;
            _logger = logger;
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar(string cpf)
        {
            _logger.LogInformation($"Buscar Cliente {cpf}");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoas = await _cliente.BuscarCliente(cpf);
            if (pessoas == null)
                return StatusCode(500);
            if (pessoas.Count() > 0)
                return Ok(pessoas);
            else if (pessoas.Count() == 0)
            {
                _logger.LogInformation($"Cliente não encontrado: {cpf}");
                return NotFound();
            }

            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(ClienteEndereco end)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var endereco = await _cliente.EditarCliente(end);
            if (endereco == 0)
                return StatusCode(500);
            if (endereco > 0)
                return Ok(endereco);
            else
                return StatusCode(500);
        }
    }
}
