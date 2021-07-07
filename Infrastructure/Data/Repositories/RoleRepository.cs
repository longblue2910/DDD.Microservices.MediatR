using AutoMapper;
using Domain.AggregateModels.Entities.RoleModels;
using Domain.DTOs.Reponses.Roles;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> CreateAsync(Role role)
        {
            dbContext.Roles.Add(role);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return $"Role name {role.RoleName} has been created success !";
            }
            return $"Create failed !";
        }

        public async Task<string> DeleteAsync(Guid roleId)
        {
            var deleteRole = dbContext.Roles.Where(r => r.Id == roleId).FirstOrDefault();
            if (deleteRole != null)
            {
                dbContext.Roles.Remove(deleteRole);
                await dbContext.SaveChangesAsync();
                return $"{roleId} has been deleted !";
            }
            return $"{roleId} not found !";
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }


        public async Task<Role> GetOrderByIdAsync(Guid roleId)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(c => c.Id == roleId);
            if (role == null)
            {
                throw new Exception(nameof(Role));

            }
            return role;
        }

        public async Task<string> UpdateAsync(Role role)
        {
            
            var editRole = dbContext.Roles.Attach(role);
            editRole.State = EntityState.Modified;
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return $"{role.Id} has been updated success !";
            }
            return $"Update failed !";
        }
    }
}
