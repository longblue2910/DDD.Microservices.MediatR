using Domain.AggregateModels.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Reponses.Brands
{
    public class BrandReponse
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public bool isDeleted { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
