using MediatR;
using TestEliteFlower.Aplication.Dto;

namespace TestEliteFlower.Aplication.Articulo.Create
{
    public class CreateArticuloCommand : IRequest<int>
    {
        public CreateArticuloDto Articulo { get; set; }
    }
}
