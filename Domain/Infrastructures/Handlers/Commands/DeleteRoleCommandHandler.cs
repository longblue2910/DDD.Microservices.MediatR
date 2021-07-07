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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, string>
    {
        private readonly IRoleService roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await roleService.DeleteAsync(request.Id);
        }
    }
}
