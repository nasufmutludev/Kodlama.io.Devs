using Application.Features.Commands.CreateLanguage;
using Application.Features.Dtos;
using Application.Features.Models;
using Application.Features.Queries.GetByIdLanguage;
using Application.Features.Queries.GetListLanguage;
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
    }
}
