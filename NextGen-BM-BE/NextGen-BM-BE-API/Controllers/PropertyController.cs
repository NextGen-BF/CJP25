using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Application.Services;
using NextGen_BM_BE_Domain.Services;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding properties
/// </summary>
[ApiController]
[Route("[controller]")]
public class PropertyController: ControllerBase {

    readonly IPropertyService _propertyService;
    public PropertyController(IPropertyService propertyService)
    {
        _propertyService=propertyService;
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllProperties(){
        var result = await _propertyService.GetAllPropertiesAsync();
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpGet]
    [Route("{propertyId}")]
    public async Task<IActionResult> GetPropertyById(int propertyId){
        var result = await _propertyService.GetPropertyByIdAsync(propertyId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IActionResult> GetPropertiesByUserId(int userId){
        var result= await _propertyService.GetPropertyByUserIdAsync(userId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpGet]
    [Route("building/{buildingId}")]
    public async Task<IActionResult> GetPropertyByBuildingId(int buildingId){
        var result= await _propertyService.GetPropertyByBuildingIdAsync(buildingId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateProperty(Property property){
        await _propertyService.CreatePropertyAsync(property);
        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateProperty(Property property){
        await _propertyService.UpdatePropertyAsync(property);
        return Ok();
    }
    [HttpPost]
    [Route("delete/{propertyId}")]
    public async Task<IActionResult> DeleteProperty(int propertyId){
        await _propertyService.DeletePropertyAsync(propertyId);
        return Ok();
    }

}
};