using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding buildings
/// </summary>
[ApiController]
[Route("[controller]")]
public class BuildingController: ControllerBase {

    private readonly IBuildingService buildingService;
    public BuildingController(IBuildingService _buildingService)
    {
        buildingService = _buildingService;
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllBuildings(){
        var result = await buildingService.GetAllBuildingsAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("{buildingId}")]
    public async Task<IActionResult> GetBuildingById(int buildingId){
        var result = await buildingService.GetBuildingByIdAsync(buildingId);
        return Ok(result);
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateBuilding(BuildingViewModel building ){
        await buildingService.CreateBuildingAsync(building);
        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateBuilding(BuildingViewModel building){
        await buildingService.UpdateBuildingAsync(building);
        return Ok();
    }

    [HttpPost]
    [Route("delete/{buildingId}")]
    public async Task<IActionResult> DeleteBuilding(int buildingId){
        await buildingService.DeleteBuildingAsync(buildingId);
        return Ok();
    }
}
}