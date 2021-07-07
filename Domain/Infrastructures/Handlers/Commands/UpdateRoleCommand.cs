using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Commands
{
    public class UpdateRoleCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
    }
}
