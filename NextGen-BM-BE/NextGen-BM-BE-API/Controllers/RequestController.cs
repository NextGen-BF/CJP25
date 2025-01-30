using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Services;

namespace NextGen_BM_BE_API.Controllers{

[ApiController]
[Route("[controller]")]
public class RequestController: ControllerBase {

    IRequestService _requestService;
    public RequestController(IRequestService requestService)
    {
        _requestService=requestService;
    }
    [HttpGet]
    [Route("building/repair/{buildingId}")]
    public async Task<IActionResult> GetRepairRequestsByBuildingId(int buildingId)
    {
        var result = await _requestService.GetAllRepairRequestsByBuildingIdAsync(buildingId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpGet]
    [Route("repair/{requestId}")]
    public async Task<IActionResult> GetRepairRequestByIdAsync(int requestId)
    {
        var result = await _requestService.GetRepairRequestByIdAsync(requestId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpGet]
    [Route("user/building/{buildingId}")]
    public async Task<IActionResult> GetUserBuildingRequestsAsync(int buildingId)
    {
        var result = await _requestService.GetUserBuildingRequestsAsync(buildingId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpPost]
    [Route("repair/new")]
    public async Task<IActionResult> CreateRepairRequest(RepairRequest repairRequest)
    {
        await _requestService.CreateRepairRequestAsync(repairRequest);
        return Ok();
    }

    [HttpPost]
    [Route("user/building/new")]
    public async Task<IActionResult> CreateUserBuildingRequest(UserBuildings userBuildings)
    {
        await _requestService.CreateUserBuildingRequestAsync();
        return Ok();
    }
    [HttpPost]
    [Route("note/new")]
    public async Task<IActionResult> CreateRepairRequestNote(RequestNotes requestNotes)
    {
        await _requestService.CreateRequestNoteAsync(requestNotes);
        return Ok();
    }

    [HttpPost]
    [Route("repair/update")]
    public async Task<IActionResult> UpdateRepairRequest(RepairRequest repairRequest)
    {
        await _requestService.UpdateRepairRequestAsync(repairRequest);
        return Ok();
    }

    [HttpPost]
    [Route("note/update")]
    public async Task<IActionResult> UpdateRequestNotes(RepairRequest repairRequest)
    {
        await _requestService.UpdateRepairRequestAsync(repairRequest);
        return Ok();
    }

    [HttpPost]
    [Route("repair/delete/{requestId}")]
    public async Task<IActionResult> DeleteRepairRequest(int requestId)
    {
        await _requestService.DeleteRepairRequestAsync(requestId);
        return Ok();
    }

    [HttpPost]
    [Route("note/delete/{requestNoteId}")]
    public async Task<IActionResult> DeleteRequestNote(int requestNoteId)
    {
        await _requestService.DeleteRepairRequestAsync(requestNoteId);
        return Ok();
    }
}
};