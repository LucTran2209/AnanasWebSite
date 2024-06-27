using Ananas.Core.Models;
using Ananas.Services.Common.Dtos.Results;
using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        public readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        /// <summary>
        /// Get the list of Color
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            try
            {           
                var colorList = await _colorService.GetAllColor();
  
                if (colorList == null)
                {
                    return NotFound();
                }

                var result = Result.Success(colorList);

                return result;
            }
            catch (Exception )
            {
                
                throw;
            }
            
        }

        //[HttpPost]
        //public async Task<IActionResult> TestFails(LucTran code)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {                  
        //            var errorData = new { Error = "Invalid input" };

        //            return Result.Failure(errorData, "Invalid input provided.", ModelState);               
        //        }

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
       
    }

    
}
