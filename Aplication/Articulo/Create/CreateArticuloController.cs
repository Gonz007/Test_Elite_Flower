using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace TestEliteFlower.Aplication.Articulo.Create
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateArticuloDto createArticuloDto)
        {
            try
            {
                var createCommand = new CreateArticuloCommand { Articulo = createArticuloDto };
                var codigoArticulo = await _mediator.Send(createCommand);

                return CreatedAtAction(nameof(GetArticulo), new { codigo = codigoArticulo }, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticulo(int codigo)
        {
            // Implementa la lógica para obtener un artículo por su código
            // Devuelve OK con los datos del artículo o NotFound si no se encuentra
            return Ok(/* Datos del artículo */);
        }
    }
}
