using Domain.AggregateModels.Entities.Products;
using Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.Products
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext context;

        public ImageRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Image> CreateAsync(Image file)
        {
            context.Images.Add(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
