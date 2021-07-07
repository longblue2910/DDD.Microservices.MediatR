using AutoMapper;
using Domain.AggregateModels.Entities.RoleModels;
using Domain.DTOs.Reponses.Roles;
using Domain.Infrastructures.Handlers.Commands;
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
        }
    }
}
