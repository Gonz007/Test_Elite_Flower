using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestEliteFlower.Aplication.Dto;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Aplication.Fabricante.Get
{
    public class GetFabricanteQueryHandler : IRequestHandler<GetFabricanteQuery, GetFabricanteResponseDto>
    {
        private readonly IRepository<Domain.Entities.Fabricante> _fabricanteRepository;

        public GetFabricanteQueryHandler(IRepository<Domain.Entities.Fabricante> fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public async Task<GetFabricanteResponseDto> Handle(GetFabricanteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var queryFabricantes = await _fabricanteRepository.GetAsync();

                if (request.Codigo > 0)
                {
                    queryFabricantes = queryFabricantes.Where(f => f.Codigo == request.Codigo);
                }

                var fabricantesDto = queryFabricantes.Select(f => new FabricanteDto
                {
                    Codigo = f.Codigo,
                    Nombre = f.Nombre
                }).ToList();

                GetFabricanteResponseDto getFabricanteResponseDto = new GetFabricanteResponseDto
                {
                    Fabricantes = fabricantesDto
                };

                return getFabricanteResponseDto;
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada
                throw ex;
            }
        }
    }
}
