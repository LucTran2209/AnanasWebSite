using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        public readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sizeList= await _sizeService.GetAll();
                var res = Result.Success(sizeList);
                return res;
            }catch (Exception) { throw; }
        }

    }

}
