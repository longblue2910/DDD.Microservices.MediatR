using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.Entities.Products
{
    [Table("Images")]
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Product Product { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public bool isDeleted { get; set; }

    }
}
