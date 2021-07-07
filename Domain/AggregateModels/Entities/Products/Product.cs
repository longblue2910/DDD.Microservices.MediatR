using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AggregateModels.Entities.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

    }
}
