﻿using Ananas.Core.Models;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.StyleService;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        public readonly IStyleService _styleService;
        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var styleList = await _styleService.GetAll();

                //result
                var res = Result.Success(styleList);
                return res;
            }
            catch (Exception) 
            { 
                throw; 
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StyleCreateInputDto style)
        {
            try
            {
                var createdStyle = await _styleService.Create(style);
                var res = Result.Success(createdStyle);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StyleUpdateInputDto style)
        {
            try
            {
                var updated = await _styleService.Update(style);
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
    }
}
