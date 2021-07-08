using AutoMapper;
using Domain.AggregateModels.Entities.Products;
using Domain.DTOs.Reponses.Categories;
using Domain.DTOs.Requests.Categories;
using Domain.Interfaces.Products.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CategoryRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<string> CreateAsync(CategoryRequest category)
        {
            var query = mapper.Map<Category>(category);
            context.Categories.Add(query);
            if (await context.SaveChangesAsync() > 0)
            {
                return $"Category name '{query.CategoryName}' has been created success !";
            }
            return "Create Failed";
        }

        public Task<string> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryRequest> EditAsync(CategoryRequest category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryReponse>> GetAllAsync()
        {
            var categories = await context.Categories.ToListAsync();
            return mapper.Map<List<CategoryReponse>>(categories);
        }

        public Task<CategoryReponse> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
