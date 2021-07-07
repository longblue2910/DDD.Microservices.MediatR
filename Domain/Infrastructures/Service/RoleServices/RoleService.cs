using Domain.AggregateModels.Entities.RoleModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructures.Service.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public async Task<string> CreateAsync(Role role)
        {
            return await roleRepository.CreateAsync(role);
        }

        public async Task<string> DeleteAsync(Guid roleId)
        {
            return await roleRepository.DeleteAsync(roleId);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetOrderByIdAsync(Guid roleId)
        {
            return await roleRepository.GetOrderByIdAsync(roleId);
        }

        public async Task<string> UpdateAsync(Role role)
        {
            return await roleRepository.UpdateAsync(role);
        }
    }
}
