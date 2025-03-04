using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_API.Controllers
{
    /// <summary>
    /// Controller for handling all API calls regarding properties
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAllProperties([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var result = await _propertyService.GetAllPropertiesAsync(page, pageSize);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("{propertyId}")]
        [Authorize(Policy = "Property User")]
        public async Task<IActionResult> GetPropertyById(int propertyId)
        {
            var result = await _propertyService.GetPropertyByIdAsync(propertyId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetPropertiesByUserId(int userId, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var result = await _propertyService.GetPropertyByUserIdAsync(userId, page, pageSize);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("building/{buildingId}")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> GetPropertyByBuildingId(int buildingId, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var result = await _propertyService.GetPropertyByBuildingIdAsync(buildingId, page, pageSize);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Policy = "Super For Property Building")]
        public async Task<IActionResult> CreateProperty(PropertyViewModel propertyViewModel)
        {
            await _propertyService.CreatePropertyAsync(propertyViewModel);
            return CreatedAtAction(
                nameof(GetPropertyById),
                new { propertyId = propertyViewModel.PropertyId },
                propertyViewModel
            );
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Policy = "Super For Property Building")]
        public async Task<IActionResult> UpdateProperty(PropertyViewModel propertyViewModel)
        {
            await _propertyService.UpdatePropertyAsync(propertyViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{propertyId}")]
        [Authorize(Policy = "Super For Property Building")]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            await _propertyService.DeletePropertyAsync(propertyId);
            return Ok();
        }

        [HttpDelete]
        [Route("resident/delete/{propertyResidentId}")]
        [Authorize(Policy = "Property Owner")]
        public async Task<IActionResult> DeletePropertyResident(int propertyResidentId)
        {
            await _propertyService.DeletePropertyResidentAsync(propertyResidentId);
            return Ok();
        }
    }
};
