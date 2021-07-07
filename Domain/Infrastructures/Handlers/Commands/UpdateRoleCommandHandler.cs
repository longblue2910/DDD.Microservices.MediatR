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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IRoleService roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Id = request.Id,
                RoleName = request.RoleName
            };
            return await roleService.UpdateAsync(role);
        }
    }
}
