using AutoMapper;
using Domain.DTOs.Requests.Products;
using Domain.Infrastructures.Service.ProductService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Commands.Products
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, string>
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductCreateCommandHandler(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public async Task<string> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductRequest
            {
                Name = request.Name,
                Price = request.Price,
                Remain = request.Remain,
                ImageFiles = request.ImageFiles,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId
            };

            return await productService.CreateAsync(result);
        }
    }
}
