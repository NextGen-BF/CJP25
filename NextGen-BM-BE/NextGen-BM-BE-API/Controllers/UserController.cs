using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding users
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase {

    public UserController()
    {
        
    }

    [HttpGet]
    [Route("/all")]
    public async Task<IActionResult> GetAllUsers(){
        return null;
    }

    [HttpGet]
    [Route("/{userID}")]
    public async Task<IActionResult> GetUserByID(int userID){
        return null;
    }

    [HttpPost]
    [Route("/property/{propertyID}")]
    public async Task<IActionResult> GetUsersByPropertyID(int propertyID){
        return null;
    }

    [HttpPost]
    [Route("/new")]
    public async Task<IActionResult> CreateUser(/*User user*/ ){
        return null;
    }

    [HttpPost]
    [Route("/update")]
    public async Task<IActionResult> UpdateUser(/*User user*/){
        return null;
    }
    [HttpPost]
    [Route("/delete/{userID}")]
    public async Task<IActionResult> DeleteUser(int userID){
        return null;
    }
}
};