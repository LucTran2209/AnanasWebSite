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
        public async Task<IActionResult> GetFilterProductDeatil([FromQuery] List<int> ListSexId,
        [FromQuery] List<int> ListCategoryId,
        [FromQuery] List<int> ListStyleId,
        [FromQuery] List<int> ListProductLineId,
        [FromQuery] List<int> ListCollectionId,
        [FromQuery] List<int> ListColorId,
        [FromQuery] List<int> ListMarketId,
        [FromQuery] List<int> ListProductStatusId,
        [FromQuery] List<int> ListPriceRanges
        )
        {
            try
            {
                var filterDto = new ProductDetailFilterInputDto
                {
                    ListSexId = MapToSexIddList(ListSexId),
                    ListCategoryId = MapToListCategoryIddList(ListCategoryId),
                    ListCollectionId = MapToListCollectionIddList(ListCollectionId),
                    ListColorId = MapToListColorIddList(ListColorId),
                    ListMarketId = MapToListMarketIddList(ListMarketId),
                    ListStyleId = MapToListStyleIddList(ListStyleId),
                    ListProductLineId = MapToListProductLineIddList(ListProductLineId),
                    ListProductStatusId = MapToListProductStatusIddList(ListProductStatusId),

                };
                var list = await _detailService.GetProductDetailFilter(filterDto);
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private List<SexIdd> MapToSexIddList(List<int> sexIds)
        {
            var list = new List<SexIdd>();
            foreach (var id in sexIds)
            {
                list.Add(new SexIdd { SexId = id });
            }
            return list;
        }

        private List<ListCategoryIdd> MapToListCategoryIddList(List<int> categoryIds)
        {
            var list = new List<ListCategoryIdd>();
            foreach (var id in categoryIds)
            {
                list.Add(new ListCategoryIdd { CategoryId = id });
            }
            return list;
        }

        private List<ListStyleIdd> MapToListStyleIddList(List<int> styleIds)
        {
            var list = new List<ListStyleIdd>();
            foreach (var id in styleIds)
            {
                list.Add(new ListStyleIdd { StyleId = id });
            }
            return list;
        }

        private List<ListProductLineIdd> MapToListProductLineIddList(List<int> productLineIds)
        {
            var list = new List<ListProductLineIdd>();
            foreach (var id in productLineIds)
            {
                list.Add(new ListProductLineIdd { ProductLineId = id });
            }
            return list;
        }

        private List<ListCollectionIdd> MapToListCollectionIddList(List<int> collectionIds)
        {
            var list = new List<ListCollectionIdd>();
            foreach (var id in collectionIds)
            {
                list.Add(new ListCollectionIdd { CollectionId = id });
            }
            return list;
        }

        private List<ListColorIdd> MapToListColorIddList(List<int> colorIds)
        {
            var list = new List<ListColorIdd>();
            foreach (var id in colorIds)
            {
                list.Add(new ListColorIdd { ColorId = id });
            }
            return list;
        }

        private List<ListMarketIdd> MapToListMarketIddList(List<int> marketIds)
        {
            var list = new List<ListMarketIdd>();
            foreach (var id in marketIds)
            {
                list.Add(new ListMarketIdd { MarketId = id });
            }
            return list;
        }

        private List<ListProductStatusIdd> MapToListProductStatusIddList(List<int> productStatusIds)
        {
            var list = new List<ListProductStatusIdd>();
            foreach (var id in productStatusIds)
            {
                list.Add(new ListProductStatusIdd { ProductStatusId = id });
            }
            return list;
        }


    }

}

