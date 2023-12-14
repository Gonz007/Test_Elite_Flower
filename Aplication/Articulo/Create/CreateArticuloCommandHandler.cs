using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestEliteFlower.Aplication.Dto;
using TestEliteFlower.Domain.Entities;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Aplication.Articulo.Create
{
    public class CreateArticuloCommandHandler : IRequestHandler<CreateArticuloCommand, int>
    {
        private readonly IRepository<Domain.Entities.Articulo> _articuloRepository;

        public CreateArticuloCommandHandler(IRepository<Domain.Entities.Articulo> articuloRepository)
        {
            _articuloRepository = articuloRepository ?? throw new ArgumentNullException(nameof(articuloRepository));
        }

        public async Task<int> Handle(CreateArticuloCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var nuevoArticulo = new Domain.Entities.Articulo
                {
                    Nombre = request.Articulo.Nombre,
                    Precio = request.Articulo.Precio,
                    Fabricante = request.Articulo.Fabricante,
                    DatosImagen = request.Articulo.DatosImagen
                };

                await _articuloRepository.AddAsync(nuevoArticulo, cancellationToken);
                await _articuloRepository.SaveChangesAsync();

                return nuevoArticulo.Codigo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el artículo: {ex.Message}");
                // Log the exception, and consider returning a custom error response
                throw new ApplicationException("Error al crear el artículo.", ex);
            }
        }
    }
}
