using Ananas.Core.Models;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.StyleService;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        public readonly IStyleService _styleService;
        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var styleList = await _styleService.GetAll();
                var res = Result.Success(styleList);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StyleCreateInputDto style)
        {
            try
            {
                var createdStyle = await _styleService.Create(style);
                var res = Result.Success(createdStyle);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StyleUpdateInputDto style)
        {
            try
            {
                var updated = await _styleService.Update(style);
                if (updated)
                {
                    return Ok(Result.Success("Update successful"));
                }
                return NotFound(Result.Failure("Style not found"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStylesByName([FromQuery] GetStylesByNameInputDtoService nameStyle)
        {
            try
            {
                var inputDto = nameStyle;
                var styles = await _styleService.GetStylesByName(inputDto);
                //var res = Result.Success(styles);
                //Console.WriteLine(styles.styles.Count);
                return Ok(styles.styles);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
