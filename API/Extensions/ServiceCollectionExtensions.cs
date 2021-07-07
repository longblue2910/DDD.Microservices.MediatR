using Domain.Infrastructures.Service.FileService;
using Domain.Infrastructures.Service.RoleServices;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
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
                .AddScoped<IFileService, FileService>();             
        }
    }
}
