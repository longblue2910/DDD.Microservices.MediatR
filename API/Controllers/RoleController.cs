using Domain.Infrastructures.Handlers.Commands;
using Domain.Infrastructures.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediatR;

        public RoleController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await mediatR.Send(new GetAllRolesQuery()));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            try
            {
                var query = new GetRoleByIdQuery(id);
                var result = await mediatR.Send(query);
                return result != null ? (IActionResult) Ok(result) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
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
        [HttpPatch]
        public async Task<IActionResult> Update(UpdateRoleCommand command)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await mediatR.Send(new DeleteRoleCommand { Id = id }));
        }
    }
}
