using Domain.AggregateModels.Entities.RoleModels;
using Domain.DTOs.Reponses.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRolesAsync();

        Task<Role> GetOrderByIdAsync(Guid roleId);
        Task<string> CreateAsync(Role role);
        Task<string> UpdateAsync(Role role);
        Task<string> DeleteAsync(Guid roleId);

    }
}
