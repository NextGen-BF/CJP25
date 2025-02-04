using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleController : ControllerBase
    {
        [HttpPost("get-google-jwt")]
        [RequireHttps]
        public async Task<IActionResult> GetGoogleJWT([FromBody] string credential)
        {
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(
                credential
            );

            return Ok(payload);
        }
    }
}
