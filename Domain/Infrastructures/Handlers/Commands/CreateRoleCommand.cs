using Domain.AggregateModels.Entities.RoleModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Domain.Infrastructures.Handlers.Commands
{
    public class CreateRoleCommand : IRequest<string>
    {
        public string RoleName { get; set; }
    }
    
}
