﻿using MediatR;
using TestEliteFlower.Aplication.Fabricante.Get;

namespace TestEliteFlower.Aplication.Fabricante.Get
{
    public class GetFabricanteQuery : IRequest<GetFabricanteResponseDto>
    {
        public int Codigo { get; set; }

        public GetFabricanteQuery(int codigo)
        {
            Codigo = codigo;
        }
    }
}
