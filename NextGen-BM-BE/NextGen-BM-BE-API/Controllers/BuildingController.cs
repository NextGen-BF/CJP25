using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

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
        [Authorize]
        public async Task<IActionResult> GetAllBuildings([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var allbuildings = await _buildingService.GetAllBuildingsAsync(page, pageSize);
            return Ok(allbuildings);
        }

        [HttpGet]
        [Route("{buildingId}")]
        [Authorize]
        public async Task<IActionResult> GetBuildingById(int buildingId)
        {
            var building = await _buildingService.GetBuildingByIdAsync(buildingId);
            return Ok(building);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetBuildingsByUserId(int userId, [FromQuery] int? page, [FromQuery] int? pageSize)
        {

            var buildings = await _buildingService.GetBuildingsByUserIdAsync(userId, page, pageSize);
            return Ok(buildings);
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Policy = "Super")]
        public async Task<IActionResult> CreateBuilding(BuildingViewModel building)
        {
            var createdBuilding = await _buildingService.CreateBuildingAsync(building);
            return Ok(createdBuilding);
        }

        [HttpDelete]
        [Route("delete/user/{userId}")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> DeleteUserBuildingLink(
            int userId,
            [FromBody] int buildingId
        )
        {
            await _buildingService.DeleteUserBuildingLinkAsync(userId, buildingId);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> UpdateBuilding(BuildingViewModel building)
        {
            await _buildingService.UpdateBuildingAsync(building);
            return Ok(building);
        }

        [HttpDelete]
        [Route("delete/{buildingId}")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            await _buildingService.DeleteBuildingAsync(buildingId);
            return Ok();
        }
    }
}
