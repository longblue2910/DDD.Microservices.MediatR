using Domain.Infrastructures.Handlers.Commands.Categories;
using Domain.Infrastructures.Handlers.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("Gets")]
        public async Task<IActionResult> Gets()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllCategoriesQuery()));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
