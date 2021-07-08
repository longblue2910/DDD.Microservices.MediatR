using Domain.DTOs.Reponses.Products;
using Domain.Interfaces.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Queries.Products
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductReponse>>
    {
        private readonly IProductRepository productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<List<ProductReponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetAll();
        }
    }
}
