using Infrastructure.DTOs;
using Infrastructure.Service;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ODataController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        //[EnableQuery]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            try
            {
                var token = await _authService.Authorize(model.Email, model.Password);
                return Ok(new
                {
                    token = token,
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                });
            }

        }
    }
}
