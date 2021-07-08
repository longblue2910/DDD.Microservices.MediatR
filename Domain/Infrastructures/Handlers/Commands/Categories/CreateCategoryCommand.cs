using Domain.DTOs.Requests.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string CategoryName { get; set; }
    }
}
