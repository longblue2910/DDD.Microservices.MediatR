using Domain.AggregateModels.Entities;
using Domain.AggregateModels.Entities.RoleModels;
using Domain.AggregateModels.Entities.UserModels;
using Infrastructure.EntitesConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.AggregateModels.Entities.FileModel;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileOnDatabaseModel> FileOnDatabase { get; set; }
        public DbSet<FileOnFileSystemModel> FileOnFileSystems { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}
