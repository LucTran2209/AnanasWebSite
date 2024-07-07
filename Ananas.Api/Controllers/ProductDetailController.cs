using Ananas.Core.OutputDataAccess;
using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        public readonly IProductDetailService _detailService;

        public ProductDetailController(IProductDetailService detailService)
        {
            _detailService = (IProductDetailService?)detailService;
        }

        //API Get All Product Detail
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var detail = await _detailService.GetAll();

                if (detail == null)
                {
                    return NotFound();
                }

                var result = Result.Success(detail);

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Api detail find by id
        [HttpGet("id")]
        public async Task<IActionResult> GetProductByid(int id)
        {
            try
            {
                var detail = await _detailService.GetById(id);

                if (detail == null)
                {
                    return NotFound();
                }

                var result = Result.Success(detail);

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Api create new detail
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(ProductDetailCreateInputDto pnew)
        {
            try
            {
                var IsCreateDetail = await _detailService.CreateNewDetail(pnew);
                if (IsCreateDetail == false)
                {
                    return BadRequest(IsCreateDetail);
                }
                else
                {
                    return Ok(IsCreateDetail);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //api update deatil by id
        [HttpPut("id")]
        public async Task<IActionResult> UpdateDetail(int id, ProductDetailCreateInputDto pnew)
        {
            try
            {
                var detail = await _detailService.UpdateDetail(id, pnew);
                return Ok(detail);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("GetFilterProductDeatil")]
        public async Task<IActionResult> GetFilterProductDeatil([FromQuery] ProductDetailFilterInputDto pfilter)
        {
            try
            {
                var list = await _detailService.GetProductDetailFilter(pfilter);
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
