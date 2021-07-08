using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.AggregateModels.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string ProductName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        public int? Remain { get; set; }
        [Required(ErrorMessage = "Chưa nhập giá!")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai giá!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Chưa chọn loại sản phẩm!")]
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        [Required(ErrorMessage = "Chưa chọn hãng sản phẩm!")]
        [ForeignKey("BrandId")]
        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public bool isDeleted { get; set; }
    }
}
