using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiDeneme.BLL;
using MyApiDeneme.DTO.LoginDTO;
using MyApiDeneme.DTO.RegisterDTO;

namespace MyApiDeneme.API.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _authService.RegisterAsync(model.Username, model.Password);

            if (!result)
            {
                return BadRequest("Username already exists.");
            }

            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _authService.LoginAsync(model.Username, model.Password);

            if (!result)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok("Login successful.");
        }
    }
}
