using Domain.DTOs.Reponses.Products;
using Domain.Interfaces.Products;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.DTOs.Requests.Brands;
using Domain.DTOs.Requests.Products;
using AutoMapper;
using Domain.AggregateModels.Entities.Products;
using System;

namespace Infrastructure.Data.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Product> CreateAsync(ProductRequest product)
        {
            var model = new Product()
            {
                ProductName = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Remain = product.Remain
          
            };
            product.Id = Guid.NewGuid();
            product.isDeledted = false;
            context.Products.Add(model);
            await context.SaveChangesAsync();
            return model;
            //var result = mapper.Map<Product>(product);
            //context.Products.Add(result);
            //await context.SaveChangesAsync();
            //return result;
        }

        public async Task<List<ProductReponse>> GetAll()
        {
            var query = await (from p in context.Products
                         join c in context.Categories on p.CategoryId equals c.Id
                         join b in context.Brands on p.BrandId equals b.Id
                         select new ProductReponse()
                         {
                             Id = p.Id,
                             ProductName = p.ProductName,
                             CategoryName =c.CategoryName,
                             Price = p.Price,
                             Remain = p.Remain,
                             BrandName = b.BrandName,
                             isDeleted = p.isDeleted
                         }).ToListAsync();
            return query;
        }
    }
}
