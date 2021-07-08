using Domain.AggregateModels.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Products
{
    public interface IImageRepository
    {
        Task<Image> CreateAsync(Image file);

    }
}
