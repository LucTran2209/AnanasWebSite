using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        public readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var discountList = await _discountService.GetAll();
                var res = Result.Success(discountList);
                return res;
            }catch (Exception) { throw; }
        }
    }
}
