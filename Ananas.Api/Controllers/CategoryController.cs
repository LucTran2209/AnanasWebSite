using Ananas.Core.Models;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.CategoryService;
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
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categoryList = await _categoryService.GetAll();
                var res = Result.Success(categoryList);
                return res;
            }
            catch (Exception ) { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateInputDto category)
        {
            try
            {
                var createdCategory = await _categoryService.Create(category);
                var res = Result.Success(createdCategory);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateInputDto category)
        {
            try
            {
                var updated = await _categoryService.Update(category);
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
        public async Task<IActionResult> GetCategoriesByName([FromQuery] GetCategoriesByNameInputDtoService nameCategory)
        {
            try
            {
                var inputDto = nameCategory;
                var categories = await _categoryService.GetCategoriesByName(inputDto);
                return Ok(categories.categories);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
