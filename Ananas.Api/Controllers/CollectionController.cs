using Ananas.Core.Models;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.CollectionService;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
                var res = Result.Success(collectionList);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CollectionCreateInputDto collection)
        {
            try
            {
                var createdCollection = await _collectionService.Create(collection);
                var res = Result.Success(createdCollection);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CollectionUpdateInputDto collection)
        {
            try
            {
                var updated = await _collectionService.Update(collection);
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
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                var collections = await _collectionService.GetByName(name);
                var res = Result.Success(collections);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
