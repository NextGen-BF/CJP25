using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding buildings
/// </summary>
[ApiController]
[Route("[controller]")]
public class BuildingController: ControllerBase {

    public BuildingController()
    {
        
    }

    [HttpGet]
    [Route("/all")]
    public async Task<IActionResult> GetAllBuildings(){
        return null;
    }

    [HttpGet]
    [Route("/{buildingID}")]
    public async Task<IActionResult> GetBuildingByID(int buildingID){
        return null;
    }

    [HttpPost]
    [Route("/new")]
    public async Task<IActionResult> CreateBuilding(/*Building building*/ ){
        return null;
    }
    [HttpPost]
    [Route("/update")]
    public async Task<IActionResult> UpdateBuilding(/*Building building*/){
        return null;
    }
    [HttpPost]
    [Route("/delete/{buildingID}")]
    public async Task<IActionResult> DeleteBuilding(int buildingID){
        return null;
    }
}
}