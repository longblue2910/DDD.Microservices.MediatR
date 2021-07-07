using Domain.AggregateModels.Entities.RoleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntitesConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.Property(r => r.RoleName)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(100)
            //    .IsRequired();
            builder.HasData(
                new Role
                {
                    Id = new Guid("a600280d-e519-41d5-998f-82fd428af9f3"),
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = new Guid("a02a928b-425c-45dc-9441-82cae13dc44a"),
                    RoleName = "Staff"
                }
            );
        }
    }
}
