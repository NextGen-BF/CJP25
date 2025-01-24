using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding properties
/// </summary>
[ApiController]
[Route("[Controller]")]
public class PropertyController: ControllerBase {

    public PropertyController()
    {
        
    }

    [HttpGet]
    [Route("/all")]
    public async Task<IActionResult> GetAllProperties(){
        return null;
    }

    [HttpGet]
    [Route("/{propertyID}")]
    public async Task<IActionResult> GetPropertyByID(int propertyID){
        return null;
    }

    [HttpGet]
    [Route("/user/{userID}")]
    public async Task<IActionResult> GetPropertiesByUserID(int userID){
        return null;
    }

    [HttpGet]
    [Route("/building/{buildingID}")]
    public async Task<IActionResult> GetPropertyByBuildingID(int buildingID){
        return null;
    }

    [HttpPost]
    [Route("/new")]
    public async Task<IActionResult> CreateProperty(/*Property property*/){
        return null;
    }

    [HttpPost]
    [Route("/update")]
    public async Task<IActionResult> UpdateProperty(/*Property property*/){
        return null;
    }

    [HttpPost]
    [Route("/delete/{propertyID}")]
    public async Task<IActionResult> DeleteProperty(int propertyID){
        return null;
    }

}
};