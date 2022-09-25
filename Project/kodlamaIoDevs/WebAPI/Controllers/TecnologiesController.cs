using Application.Features.Tecnologies.Commands.CreateTechnologies;
using Application.Features.Tecnologies.Commands.DeleteTechnologies;
using Application.Features.Tecnologies.Commands.UpdateTechnologies;
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologiesCommand updateTechnologiesCommand)
        {
            var result = await Mediator.Send(updateTechnologiesCommand);
            return Ok(result);
        }
    }
}
