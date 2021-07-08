using Domain.DTOs.Reponses.Brands;
using Domain.Interfaces.Products.Brands;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Queries.Brands
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<BrandReponse>>
    {
        private readonly IBrandRepository brandRepository;

        public GetAllBrandQueryHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<List<BrandReponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return await brandRepository.GetAllAsync();
        }
    }
}
