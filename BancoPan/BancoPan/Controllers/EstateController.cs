using BancoPan.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoPan.Controllers
{
    public class EstateController : ControllerBase
    {
        private readonly IIbgeService _ibgeService;
        private readonly ILogger<EstateController> _logger;
        public EstateController(IIbgeService ibgeService, ILogger<EstateController> logger)
        {
            _logger = logger;
            _ibgeService = ibgeService;
        }

        [HttpGet("BuscarEstados")]
        public async Task<IActionResult> BuscarEstados()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var estados = await _ibgeService.SearchEstates();
            if (estados == null)
                return StatusCode(500);
            else
                return Ok(estados);
        }

        [HttpGet("BuscarMunicipios")]
        public async Task<IActionResult> BuscarMunicipios(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var municipios = await _ibgeService.SearchCounties(id);
            if (municipios == null)
                return NotFound();
            else
                return Ok(municipios);
        }
    }
}
