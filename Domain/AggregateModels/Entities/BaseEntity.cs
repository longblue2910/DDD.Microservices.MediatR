using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.AggregateModels.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

    }
}
