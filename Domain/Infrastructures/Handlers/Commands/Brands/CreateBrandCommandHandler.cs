using AutoMapper;
using Domain.DTOs.Requests.Brands;
using Domain.Interfaces.Products.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Commands.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, string>
    {
        private readonly IMapper mapper;
        private readonly IBrandRepository brandRepository;

        public CreateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            this.mapper = mapper;
            this.brandRepository = brandRepository;
        }
        public async Task<string> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<BrandRequest>(request);
            return await brandRepository.CreateAsync(result);
        }
    }
}
