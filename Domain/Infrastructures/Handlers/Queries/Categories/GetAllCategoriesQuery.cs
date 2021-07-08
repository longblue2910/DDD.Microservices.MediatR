using Domain.DTOs.Reponses.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Queries.Categories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryReponse>>
    {
    }
}
