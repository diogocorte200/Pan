using BancoPan.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoPan.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IViaCepService _viaCepService;
        public AddressController(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }


        [HttpGet("BuscarCep")]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var address = await _viaCepService.SearchAddress(cep);
            if (address == null)
                return StatusCode(500);
            else
                return Ok(address);
        }

        
    }
}
