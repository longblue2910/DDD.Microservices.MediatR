using AutoMapper;
using Domain.DTOs.Reponses.Roles;
using Domain.Infrastructures.Service.RoleServices;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Queries
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleReponse>>
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public GetAllRolesQueryHandler(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }
        public async Task<List<RoleReponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var query = await roleService.GetAllRolesAsync();
            var vm = mapper.Map<List<RoleReponse>>(query);
            return vm;
        }
    }
}
