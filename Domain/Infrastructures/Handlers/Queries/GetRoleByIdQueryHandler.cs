using AutoMapper;
using Domain.AggregateModels.Entities.RoleModels;
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
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleReponse>
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public GetRoleByIdQueryHandler(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }
        public async Task<RoleReponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await roleService.GetOrderByIdAsync(request.Id);
            var vm = mapper.Map<RoleReponse>(query);
            return vm;
        }
    }
}
