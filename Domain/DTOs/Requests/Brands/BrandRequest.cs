using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Requests.Brands
{
    public class BrandRequest
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public bool isDeleted { get; set; }
    }
}
