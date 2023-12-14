using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestEliteFlower.Aplication.Articulo.Get;

namespace TestEliteFlower.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int codigo)
        {
            try
            {
                if (codigo <= 0)
                {
                    // Handle the case where an invalid code is provided
                    return BadRequest("Código de artículo no válido");
                }

                var query = new GetArticuloQuery(codigo);
                var result = await _mediator.Send(query);

                if (result != null && result.Articulos.Count > 0)
                {
                    return Ok(new GetArticuloResponseDto { Articulos = result.Articulos });
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
