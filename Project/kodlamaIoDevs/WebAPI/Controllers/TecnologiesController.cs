using Application.Features.Tecnologies.Commands.CreateTechnologies;
using Application.Features.Tecnologies.Commands.DeleteTechnologies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTechnologiesCommand createTechnologiesCommand)
        {
            var result = await Mediator.Send(createTechnologiesCommand);
            return Created("", result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologiesCommand deleteTechnologiesCommand)
        {
            var result = await Mediator.Send(deleteTechnologiesCommand);
            return Ok(result);
        }
    }
}
