using Domain.AggregateModels.Entities.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.Entities.RoleModels
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
