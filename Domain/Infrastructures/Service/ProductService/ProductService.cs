using Domain.AggregateModels.Entities.Products;
using Domain.DTOs.Requests.Products;
using Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IImageRepository imageRepository;

        public ProductService(IProductRepository productRepository, IImageRepository imageRepository)
        {
            this.productRepository = productRepository;
            this.imageRepository = imageRepository;
        }
        public async Task<string> CreateAsync(ProductRequest product)
        {
            var result = await productRepository.CreateAsync(product);
            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Products\\");
                    bool basePathExists = System.IO.Directory.Exists(basePath);
                    if (!basePathExists) Directory.CreateDirectory(basePath);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var filePath = Path.Combine(basePath, file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var fileModel = new Image
                    {
                        Id = Guid.NewGuid(),
                        CreatedOn = DateTime.UtcNow,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = Guid.NewGuid().ToString(),
                        ProductId = result.Id
                    };
                    await imageRepository.CreateAsync(fileModel);
                }
            }
            return $"Create product '{result.ProductName}' has been success.";
        }
    }
}
