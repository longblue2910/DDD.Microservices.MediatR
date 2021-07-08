using AutoMapper;
using Domain.AggregateModels.Entities.Products;
using Domain.AggregateModels.Entities.RoleModels;
using Domain.DTOs.Reponses.Brands;
using Domain.DTOs.Reponses.Categories;
using Domain.DTOs.Reponses.Roles;
using Domain.DTOs.Requests.Brands;
using Domain.DTOs.Requests.Categories;
using Domain.DTOs.Requests.Products;
using Domain.Infrastructures.Handlers.Commands;
using Domain.Infrastructures.Handlers.Commands.Brands;
using Domain.Infrastructures.Handlers.Commands.Categories;
using Domain.Infrastructures.Handlers.Commands.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Mapping
{
    public class AppMapperConfiguration
    {
        public static List<Profile> RegisterMappings()
        {
            var cfg = new List<Profile>
            {
                // Thêm các MappingProfile khác vào đây
                new MappingProfile()
            };

            return cfg;
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Đưa hết các cấu hình bạn muốn map giữa các object vào đây
            CreateMap<Role, RoleReponse>();

            //Category
            CreateMap<Category, CategoryReponse>();
            CreateMap<CreateCategoryCommand, CategoryRequest>();
            CreateMap<CategoryRequest, Category>();

            //Brand
            CreateMap<Brand, BrandReponse>();
            CreateMap<BrandRequest, Brand>();
            CreateMap<CreateBrandCommand, BrandRequest>();

            //Product
            CreateMap<ProductRequest, Product>();
            CreateMap<ProductCreateCommand, ProductRequest>();

        }
    }
}
