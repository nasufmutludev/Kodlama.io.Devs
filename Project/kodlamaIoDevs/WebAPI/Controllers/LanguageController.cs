using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            //GetListLanguageQuery getListLanguageQuery = new GetListLanguageQuery();
            //Yeni Kullanım
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            GetByIdLanguageDto getByIdLanguageDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(getByIdLanguageDto);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdateLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeleteLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Ok(result);
        }
    }
}
