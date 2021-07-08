using Domain.DTOs.Reponses.Categories;
using Domain.Interfaces.Products.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Queries.Categories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryReponse>>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryReponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAllAsync();
        }
    }
}
