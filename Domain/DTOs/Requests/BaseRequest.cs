using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Requests
{
    public class BaseRequest
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
