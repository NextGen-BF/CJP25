using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Services;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_API.Controllers
{

[ApiController]
[Route("[controller]")]
public class RequestController: ControllerBase {

    private readonly IRequestService _requestService;
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
        public async Task<IActionResult> GetRepairRequestById(int requestId)
        {
            var result = await _requestService.GetRepairRequestByIdAsync(requestId);
            if (result == null) return BadRequest();
            return Ok(result);
        }

    [HttpGet]
    [Route("user/building/{buildingId}")]
    public async Task<IActionResult> GetUserBuildingRequests(int buildingId)
    {
        var result = await _requestService.GetUserBuildingRequestsAsync(buildingId);
        if (result==null) return BadRequest();
        return Ok(result);
    }

    [HttpPost]
    [Route("repair/new")]
    public async Task<IActionResult> CreateRepairRequest(RepairRequestViewModel repairRequestViewModel)
    {
        await _requestService.CreateRepairRequestAsync(repairRequestViewModel);
        return CreatedAtAction(nameof(GetRepairRequestById), new {requestId=repairRequestViewModel.RequestId}, repairRequestViewModel);
    }

        [HttpPost]
        [Route("user/building/new")]
        public async Task<IActionResult> CreateUserBuildingRequest(UserBuildingsViewModel userBuildings)
        {
            await _requestService.CreateUserBuildingRequestAsync(userBuildings);
            return CreatedAtAction(nameof(GetUserBuildingRequests), new { buildingId = userBuildings.BuildingId }, userBuildings);
        }
        [HttpPost]
        [Route("note/new")]
        public async Task<IActionResult> CreateRepairRequestNote(RequestNotesViewModel requestNotesViewModel)
        {
            var note = await _requestService.CreateRequestNoteAsync(requestNotesViewModel);
            //TODO: when notes gain more priority and/if fe needs to make an api call to get notes seperately, pass that method
            return Ok(note);
        }

        [HttpPut]
        [Route("repair/update")]
        public async Task<IActionResult> UpdateRepairRequest(RepairRequestViewModel repairRequestViewModel)
        {
            await _requestService.UpdateRepairRequestAsync(repairRequestViewModel);
            return Ok();
        }

        [HttpPut]
        [Route("note/update")]
        public async Task<IActionResult> UpdateRequestNotes(RequestNotesViewModel requestNotesViewModel)
        {
            await _requestService.UpdateRequestNoteAsync(requestNotesViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("repair/delete/{requestId}")]
        public async Task<IActionResult> DeleteRepairRequest(int requestId)
        {
            await _requestService.DeleteRepairRequestAsync(requestId);
            return Ok();
        }

        [HttpDelete]
        [Route("note/delete/{requestNoteId}")]
        public async Task<IActionResult> DeleteRequestNote(int requestNoteId)
        {
            await _requestService.DeleteRepairRequestAsync(requestNoteId);
            return Ok();
        }
    }
};