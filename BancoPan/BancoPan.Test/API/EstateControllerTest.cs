using BancoPan.Controllers;
using BancoPan.Domain.Domain;
using BancoPan.Domain.Interfaces;
using BancoPan.Domain.Services;
using BancoPan.Entity.Entity;
using BancoPan.Test.Fake;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace BancoPan.Test.API
{
    public class EstateControllerTest
    {
        private readonly IIbgeService _ibgeService;
        private readonly ILogger<EstateController> _logger;
        private readonly EstateController _controller;

        public EstateControllerTest()
        {
            _ibgeService = Substitute.For<IIbgeService>();
            _logger = Substitute.For<ILogger<EstateController>>();
            _controller = new EstateController(_ibgeService, _logger);
        }

        [Fact]
        public async Task Should_ReturnNotFound_When_NotFound_MunicipiosId()
        {
            var response = await _controller.BuscarMunicipios(99999);
            response.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }


        [Fact]
        public async Task Should_ReturnOk_When_Found_Municipios()
        {
            _ibgeService.SearchCounties(Arg.Any<int>()).Returns(MunicipioFake.GetMunicipiosValid());
            var response = await _controller.BuscarMunicipios(11);
            response.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
