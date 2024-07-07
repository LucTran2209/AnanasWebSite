using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        public readonly IMarketService _marketService;
        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var marketList = await _marketService.GetAll();

                // Result
                var res = Result.Success(marketList);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
