using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                // Result
                var res = Result.Success(styleList);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
