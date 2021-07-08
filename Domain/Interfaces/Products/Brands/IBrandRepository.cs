using Domain.DTOs.Reponses.Brands;
using Domain.DTOs.Requests.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Products.Brands
{
    public interface IBrandRepository
    {
        Task<List<BrandReponse>> GetAllAsync();
        Task<BrandReponse> GetByIdAsync(Guid id);
        Task<string> CreateAsync(BrandRequest brand);
        Task<BrandRequest> EditAsync(BrandRequest brand);
        Task<string> DeleteAsync(Guid id);
    }
}
