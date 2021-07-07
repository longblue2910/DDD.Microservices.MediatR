using AutoMapper;
using Domain.AggregateModels.Entities.RoleModels;
using Domain.Infrastructures.Service.RoleServices;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Handlers.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRoleService roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                RoleName = request.RoleName
            };
            return await roleService.CreateAsync(role);
        }


        //public async Task<int> IRequestHandler<CreateRoleCommand, int>Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        //{
        //    var role = mapper.Map<Role>(request);
        //    return await roleRepository.CreateAsync(role);
        //}
    }
}
