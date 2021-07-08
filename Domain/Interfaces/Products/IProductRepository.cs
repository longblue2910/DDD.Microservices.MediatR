using Domain.AggregateModels.Entities.Products;
using Domain.DTOs.Reponses.Products;
using Domain.DTOs.Requests.Brands;
using Domain.DTOs.Requests.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<List<ProductReponse>> GetAll();
        Task<Product> CreateAsync(ProductRequest product);
    }
}
