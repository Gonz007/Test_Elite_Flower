using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestEliteFlower.Aplication.Dto;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Aplication.Articulo.Get
{
    public class GetArticuloQueryHandler : IRequestHandler<GetArticuloQuery, GetArticuloResponseDto>
    {
        private readonly IRepository<Domain.Entities.Articulo> _articuloRepository;

        public GetArticuloQueryHandler(IRepository<Domain.Entities.Articulo> articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<GetArticuloResponseDto> Handle(GetArticuloQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var queryArticulos = await _articuloRepository.GetAsync();

                if (request.Codigo > 0)
                {
                    queryArticulos = queryArticulos.Where(a => a.Codigo == request.Codigo);
                }

                var articulosDto = queryArticulos.Select(a => new ArticuloDto
                {
                    Codigo = a.Codigo,
                    Nombre = a.Nombre,
                    Precio = a.Precio,
                    Fabricante = a.Fabricante,
                    DatosImagen = a.DatosImagen
                }).ToList();

                GetArticuloResponseDto getArticuloResponseDto = new GetArticuloResponseDto
                {
                    Articulos = articulosDto
                };

                return getArticuloResponseDto;
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada
                throw ex;
            }
        }
    }
}
