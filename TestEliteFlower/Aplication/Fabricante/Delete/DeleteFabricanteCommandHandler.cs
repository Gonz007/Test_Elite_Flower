using MediatR;
using TestEliteFlower.Domain.Interfaces;

namespace TestEliteFlower.Aplication.Fabricante.Delete
{
    public class DeleteFabricanteCommandHandler : IRequestHandler<DeleteFabricanteCommand, DeleteFabricanteResponseDto>
    {
        private readonly IRepository<Domain.Entities.Fabricante> _fabricanteRepository;

        public DeleteFabricanteCommandHandler(IRepository<Domain.Entities.Fabricante> fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository ?? throw new ArgumentNullException(nameof(fabricanteRepository));
        }

        public async Task<DeleteFabricanteResponseDto> Handle(DeleteFabricanteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fabricante = await _fabricanteRepository.GetByIdAsync(request.Codigo);

                if (fabricante == null)
                {
                    return new DeleteFabricanteResponseDto
                    {
                        Message = $"No se encontró el fabricante con el código {request.Codigo}"
                    };
                }

                _fabricanteRepository.Delete(fabricante);
                await _fabricanteRepository.SaveChangesAsync();

                return new DeleteFabricanteResponseDto
                {
                    DeletedCodigo = fabricante.Codigo,
                    Message = "Fabricante eliminado exitosamente",
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el fabricante: {ex.Message}");
                throw;
            }
        }
    }
}
