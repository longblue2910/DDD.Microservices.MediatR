using Domain.AggregateModels.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Reponses.Products
{
    public class ProductReponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int? Remain { get; set; }
        public float Price { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public bool isDeleted { get; set; }
    }
}
