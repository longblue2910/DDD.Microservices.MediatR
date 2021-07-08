using AutoMapper;
using Domain.AggregateModels.Entities.Products;
using Domain.DTOs.Reponses.Brands;
using Domain.DTOs.Requests.Brands;
using Domain.Interfaces.Products.Brands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.Products
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public BrandRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<string> CreateAsync(BrandRequest brand)
        {
            var query = mapper.Map<Brand>(brand);
            context.Brands.Add(query);
            if (await context.SaveChangesAsync() > 0)
            {
                return $"Brand name '{query.BrandName}' has been created success !";
            }
            return "Create Failed";
        }

        public Task<string> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandRequest> EditAsync(BrandRequest brand)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BrandReponse>> GetAllAsync()
        {
            var brands = await context.Brands.ToListAsync();
            return mapper.Map<List<BrandReponse>>(brands);
        }

        public Task<BrandReponse> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();

        }
    }
}
