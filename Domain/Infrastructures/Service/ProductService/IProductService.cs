using Domain.DTOs.Requests.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Service.ProductService
{
    public interface IProductService
    {
        Task<string> CreateAsync(ProductRequest product);

    }
}
