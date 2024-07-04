using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexController : ControllerBase
    {
        public readonly ISexService _sexService;
        public SexController(ISexService sexService)
        {
            _sexService = sexService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sexList = await _sexService.GetAll();
                var res = Result.Success(sexList);
                return res;
            }catch (Exception) { throw; }
        }
    }
}
