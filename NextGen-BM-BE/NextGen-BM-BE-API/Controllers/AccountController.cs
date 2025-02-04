using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_API.Controllers{

    [ApiController]
    [Route("[controller]/auth")]
    public class AccountController : ControllerBase{
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(new { Result = "User created successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.LoginAsync(model);
            if(token == null) return Unauthorized(new { message = "Invalid credentials" });
            return Ok(new { token });
        }
}
}