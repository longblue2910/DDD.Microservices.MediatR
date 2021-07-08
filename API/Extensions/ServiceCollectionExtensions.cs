using Domain.Infrastructures.Service.FileService;
using Domain.Infrastructures.Service.ProductService;
using Domain.Infrastructures.Service.RoleServices;
using Domain.Interfaces;
using Domain.Interfaces.Products;
using Domain.Interfaces.Products.Brands;
using Domain.Interfaces.Products.Categories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
                     options.UseNpgsql(configuration.GetConnectionString("DbConnection")));
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IRoleService, RoleService>()

                .AddScoped<IFileRepository, FileRepository>()
                .AddScoped<IFileService, FileService>()

                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IBrandRepository, BrandRepository>()

                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProductService, ProductService>()
                
                .AddScoped<IImageRepository, ImageRepository>();

                
        }
    }
}
