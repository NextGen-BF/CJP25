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
        return Ok(result);
    }

    [HttpGet]
    [Route("{propertyId}")]
    public async Task<IActionResult> GetPropertyById(int propertyId){
        var result = await _propertyService.GetPropertyByIdAsync(propertyId);
        return Ok(result);
    }

    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IActionResult> GetPropertiesByUserId(int userId){
        return null;
    }

    [HttpGet]
    [Route("building/{buildingId}")]
    public async Task<IActionResult> GetPropertyByBuildingId(int buildingId){
        return null;
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateProperty(Property property){
        return null;
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateProperty(Property property){
        return null;
    }

    [HttpPost]
    [Route("delete/{propertyId}")]
    public async Task<IActionResult> DeleteProperty(int propertyId){
        return null;
    }

}
};