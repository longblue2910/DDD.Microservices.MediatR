using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.AggregateModels.Entities.Products
{
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string BrandName { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool isDeleted { get; set; }
    }
}
