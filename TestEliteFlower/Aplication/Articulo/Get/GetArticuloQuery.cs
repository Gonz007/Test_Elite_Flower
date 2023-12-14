using MediatR;

namespace TestEliteFlower.Aplication.Articulo.Get
{
    public class GetArticuloQuery : IRequest<GetArticuloResponseDto>
    {
        public int Codigo { get; set; }

        public GetArticuloQuery(int codigo)
        {
            Codigo = codigo;
        }

    }
}
