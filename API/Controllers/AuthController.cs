using Infrastructure.DTOs;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
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
