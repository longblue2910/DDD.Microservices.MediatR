using Domain.Infrastructures.Handlers.Commands.Products;
using Domain.Infrastructures.Handlers.Queries.Products;
using Domain.Interfaces.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediatR;

        public ProductController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }
        [HttpGet]
        [Route("Gets")]
        public async Task<IActionResult> Gets()
        {
           
            return Ok(await mediatR.Send(new GetAllProductsQuery()));
           
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm]ProductCreateCommand command)
        {
            try
            {
                return Ok(await mediatR.Send(command));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
