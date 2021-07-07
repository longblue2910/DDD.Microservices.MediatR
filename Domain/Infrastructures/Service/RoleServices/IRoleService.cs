using Domain.AggregateModels.Entities.RoleModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Service.RoleServices
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();

        Task<Role> GetOrderByIdAsync(Guid roleId);
        Task<string> CreateAsync(Role role);
        Task<string> UpdateAsync(Role role);
        Task<string> DeleteAsync(Guid roleId);
    }
}
