using MediatR;

namespace TestEliteFlower.Aplication.Fabricante.Delete
{
    public class DeleteFabricanteCommand : IRequest<DeleteFabricanteResponseDto>
    {
        public int Codigo { get; set; }
    }
}
