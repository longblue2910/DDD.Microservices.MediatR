using Domain.AggregateModels.Entities.RoleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.Entities.UserModels
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
