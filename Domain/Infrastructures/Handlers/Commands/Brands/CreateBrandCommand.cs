using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Commands.Brands
{
    public class CreateBrandCommand : IRequest<string>
    {
        public string BrandName { get; set; }
    }
}
