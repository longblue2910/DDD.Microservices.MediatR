using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.Entities.Products
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
