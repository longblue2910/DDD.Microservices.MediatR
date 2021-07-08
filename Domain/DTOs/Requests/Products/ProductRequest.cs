using Domain.AggregateModels.Entities.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs.Requests.Products
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên sản phẩm!")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa nhập giá!")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai giá!")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Chưa chọn thương hiệu!")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Chưa nhập vào số lượng trong kho!")]
        [Range(1, int.MaxValue, ErrorMessage = "Nhập sai số lượng!")]
        public int? Remain { get; set; }

        [Required(ErrorMessage = "Chưa chọn loại sản phẩm!")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IEnumerable<IFormFile> ImageFiles { get; set; }
        public bool isDeledted { get; set; }
    }
}
