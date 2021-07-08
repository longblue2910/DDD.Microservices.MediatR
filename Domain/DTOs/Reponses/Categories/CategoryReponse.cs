using Domain.AggregateModels.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Reponses.Categories
{
    public class CategoryReponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public bool isDeleted { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
