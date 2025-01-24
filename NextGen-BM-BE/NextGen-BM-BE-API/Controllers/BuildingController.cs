using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding buildings
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BuildingController: ControllerBase {

    public BuildingController()
    {
        
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllBuildings(){
        return null;
    }

    [HttpGet]
    [Route("{buildingId}")]
    public async Task<IActionResult> GetBuildingById(int buildingId){
        return null;
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateBuilding(Building building ){
        return null;
    }
    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateBuilding(Building building){
        return null;
    }
    [HttpPost]
    [Route("delete/{buildingId}")]
    public async Task<IActionResult> DeleteBuilding(int buildingId){
        return null;
    }
}
}