using AutoMapper;
using Domain.DTOs.Requests.Categories;
using Domain.Interfaces.Products.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Commands.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<CategoryRequest>(request);
            return await categoryRepository.CreateAsync(result);
        }
    }
}
