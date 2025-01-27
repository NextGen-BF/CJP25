using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_API.Controllers{

[ApiController]
[Route("[controller]")]
public class RequestController: ControllerBase {

    [HttpGet]
    [Route("building/repair/{buildingId}")]
    public Task<IActionResult> GetRepairRequestsByBuildingId(int buildingId)
    {
        return null;
    }

    [HttpGet]
    [Route("repair/{requestId}")]
    public Task<IActionResult> GetRepairRequestById(int requestId)
    {
        return null;
    }

    [HttpGet]
    [Route("user/building/{buildingId}")]
    public Task<IActionResult> GetUserBuildingRequests(int buildingId)
    {
        return null;
    }

    [HttpPost]
    [Route("repair/new")]
    public Task<IActionResult> CreateRepairRequest(RepairRequest repairRequest)
    {
        return null;
    }

    [HttpPost]
    [Route("user/building/new")]
    public Task<IActionResult> CreateUserBuildingRequest(UserBuildings userBuildings)
    {
        return null;
    }
    [HttpPost]
    [Route("note/new")]
    public Task<IActionResult> CreateRepairRequestNote(RequestNotes requestNotes)
    {
        return null;
    }

    [HttpPost]
    [Route("repair/update/")]
    public Task<IActionResult> UpdateRepairRequest(RepairRequest repairRequest)
    {
        return null;
    }

    [HttpPost]
    [Route("note/update")]
    public Task<IActionResult> UpdateRequestNotes(RepairRequest repairRequest)
    {
        return null;
    }

    [HttpPost]
    [Route("repair/delete/{requestId}")]
    public Task<IActionResult> DeleteRepairRequest(int requestId)
    {
        return null;
    }

    [HttpPost]
    [Route("note/delete/{requestNoteId}")]
    public Task<IActionResult> DeleteRequestNote(int requestNoteId)
    {
        return null;
    }
}
};