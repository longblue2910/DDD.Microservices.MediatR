using Domain.DTOs.Reponses.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Queries.Products
{
    public class GetAllProductsQuery : IRequest<List<ProductReponse>>
    {
    }
}
