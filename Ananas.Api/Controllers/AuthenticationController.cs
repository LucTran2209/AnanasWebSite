using Ananas.Services.Interfaces;
using ApplicationCommon.Abstractions.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ananas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticaitonService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticaitonService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginByUserNamePassword(string userName, string password)
        {
            try
            {
                var res = Result.Success(await _authenticaitonService.LoginByUserNameAndPassword(userName, password));
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
