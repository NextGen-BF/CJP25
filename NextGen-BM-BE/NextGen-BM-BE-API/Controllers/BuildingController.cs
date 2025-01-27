using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

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
    [Route("all")]
    public async Task<IActionResult> GetAllBuildings(){
        return Ok();
    }

    [HttpGet]
    [Route("{buildingId}")]
    public async Task<IActionResult> GetBuildingById(int buildingId){
        return Ok();
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateBuilding(Building building ){
        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateBuilding(Building building){
        return Ok();
    }
    
    [HttpPost]
    [Route("delete/{buildingId}")]
    public async Task<IActionResult> DeleteBuilding(int buildingId){
        return Ok();
    }
}
}