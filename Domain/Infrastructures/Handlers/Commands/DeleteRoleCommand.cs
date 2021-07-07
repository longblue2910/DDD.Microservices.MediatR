using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Commands
{
    public class DeleteRoleCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
