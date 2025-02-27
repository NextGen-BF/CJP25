using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers
{

    /// <summary>
    /// Controller for handling all API calls regarding users
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            return null;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("property/{propertyId}")]
        public async Task<IActionResult> GetUsersByPropertyId(int propertyId)
        {
            return null;
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(/*User user*/)
        {
            return null;
        }
        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            return null;
        }
    }
};