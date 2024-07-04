using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        public readonly ICollectionService _collectionService;
        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var collectionList = await _collectionService.GetAll();

                // Result
                var res = Result.Success(collectionList);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
