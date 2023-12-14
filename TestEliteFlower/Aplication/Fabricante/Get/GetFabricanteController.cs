using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestEliteFlower.Aplication.Fabricante.Get;

namespace TestEliteFlower.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricanteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FabricanteController(IMediator mediator)
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
                    // Manejar el caso en que no se proporciona un código válido
                    return BadRequest("Código de fabricante no válido");
                }

                var query = new GetFabricanteQuery(codigo);
                var result = await _mediator.Send(query);

                if (result != null && result.Fabricantes.Count > 0)
                {
                    return Ok(new GetFabricanteResponseDto { Fabricantes = result.Fabricantes });
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
