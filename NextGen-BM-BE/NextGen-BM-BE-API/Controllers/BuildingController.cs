using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_API.Controllers
{
    /// <summary>
    /// Controller for handling all API calls regarding buildings
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var allbuildings = await _buildingService.GetAllBuildingsAsync();
            return Ok(allbuildings);
        }

        [HttpGet]
        [Route("{buildingId}")]
        public async Task<IActionResult> GetBuildingById(int buildingId)
        {
            var building = await _buildingService.GetBuildingByIdAsync(buildingId);
            return Ok(building);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateBuilding(Building building)
        {
            await _buildingService.CreateBuildingAsync(building);
            return CreatedAtAction(
                nameof(GetBuildingById),
                new { id = building.BuildingId },
                building
            );
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateBuilding(Building building)
        {
            await _buildingService.UpdateBuildingAsync(building);
            return Ok(building);
        }

        [HttpDelete]
        [Route("delete/{buildingId}")]
        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            await _buildingService.DeleteBuildingAsync(buildingId);
            return Ok();
        }
    }
}
