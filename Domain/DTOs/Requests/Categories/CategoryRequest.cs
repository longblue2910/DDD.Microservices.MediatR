using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Requests.Categories
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public bool isDeleted { get; set; }
    }
}
