using Domain.AggregateModels.Entities.RoleModels;
using Domain.DTOs.Reponses.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Queries
{
    public class GetAllRolesQuery : IRequest<List<RoleReponse>>
    {
    }
}
