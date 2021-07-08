using Domain.DTOs.Reponses.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructures.Handlers.Queries.Brands
{
    public class GetAllBrandQuery : IRequest<List<BrandReponse>>
    {
    }
}
