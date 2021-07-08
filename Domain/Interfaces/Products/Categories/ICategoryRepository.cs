using Domain.DTOs.Reponses.Categories;
using Domain.DTOs.Requests.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Products.Categories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryReponse>> GetAllAsync();
        Task<CategoryReponse> GetByIdAsync(Guid id);
        Task<string> CreateAsync(CategoryRequest category);
        Task<CategoryRequest> EditAsync(CategoryRequest category);
        Task<string> DeleteAsync(Guid id);

    }
}
