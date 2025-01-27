using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding users
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase {

    public UserController()
    {
        
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllUsers(){
        return null;
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetUserById(int userId){
        return null;
    }

    [HttpPost]
    [Route("property/{propertyId}")]
    public async Task<IActionResult> GetUsersByPropertyId(int propertyId){
        return null;
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateUser(/*User user*/){
        return null;
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateUser(/*User user*/){
        return null;
    }
    [HttpPost]
    [Route("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId){
        return null;
    }
}
};