using NextGen_BM_BE_Application.UseCases.Requests.Create;
using NextGen_BM_BE_Application.UseCases.Requests.Delete;
using NextGen_BM_BE_Application.UseCases.Requests.Get;
using NextGen_BM_BE_Application.UseCases.Requests.Update;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Services;

public class RequestService : IRequestService
{
    readonly CreateRepairRequestUseCase _createRepairRequestUseCase;
    readonly CreateRequestNotesUseCase _createRequestNoteUseCase;
    readonly CreateUserBuildingRequestUseCase _createUserBuildingRequestUseCase;
    readonly DeleteRepairRequestNoteUseCase _deleteRepairRequestNoteUseCase;
    readonly DeleteRepairRequestUseCase _deleteRepairRequestUseCase;
    readonly GetAllRepairRequestsByBuildingIdUseCase _getAllRepairRequestsByBuildingIdUseCase;
    readonly GetUserBuildingRequests _getUserBuildingRequests;
    readonly GetRequestByIdUseCase _getRequestByIdUseCase; 
    readonly UpdateRepairRequestUseCase _updateRepairRequestUseCase;
    readonly UpdateRequestNoteUseCase _updateRequestNoteUseCase;
    public RequestService( CreateRepairRequestUseCase createRepairRequestUseCase,
                            CreateRequestNotesUseCase createRequestNoteUseCase,
                            CreateUserBuildingRequestUseCase createUserBuildingRequestUseCase,
                            DeleteRepairRequestNoteUseCase deleteRepairRequestNoteUseCase,
                            DeleteRepairRequestUseCase deleteRepairRequestUseCase,
                            GetAllRepairRequestsByBuildingIdUseCase getAllRepairRequestsByBuildingIdUseCase,
                            GetRequestByIdUseCase getRequestByIdUseCase,
                            UpdateRepairRequestUseCase updateRepairRequestUseCase,
                            UpdateRequestNoteUseCase updateRequestNoteUseCase)
    {
        _createRepairRequestUseCase=createRepairRequestUseCase;
        _createRequestNoteUseCase=createRequestNoteUseCase;
        _createUserBuildingRequestUseCase=createUserBuildingRequestUseCase;
        _deleteRepairRequestNoteUseCase=deleteRepairRequestNoteUseCase;
        _deleteRepairRequestUseCase=deleteRepairRequestUseCase;
        _getAllRepairRequestsByBuildingIdUseCase=getAllRepairRequestsByBuildingIdUseCase;
        _getRequestByIdUseCase=getRequestByIdUseCase;
        _updateRepairRequestUseCase=updateRepairRequestUseCase;
        _updateRequestNoteUseCase=updateRequestNoteUseCase;
    }
    public async Task CreateRepairRequestAsync(RepairRequest repairRequest)
    {
        await _createRepairRequestUseCase.Execute(repairRequest);
    }

    public async Task CreateRequestNoteAsync(RequestNotes requestNotes)
    {
        await _createRequestNoteUseCase.Execute(requestNotes);
    }

    public Task CreateUserBuildingRequestAsync()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRepairRequestAsync(int requestId)
    {
        await _deleteRepairRequestUseCase.Execute(requestId);
    }

    public async Task DeleteRepairRequestNoteAsync(int requestNoteId)
    {
        await _deleteRepairRequestNoteUseCase.Execute(requestNoteId);
    }

    public async Task<IList<RepairRequest>> GetAllRepairRequestsByBuildingIdAsync(int buildingId)
    {
        return await _getAllRepairRequestsByBuildingIdUseCase.Execute(buildingId);
    }

    public async Task<RepairRequest> GetRepairRequestByIdAsync(int requestId)
    {
        return await _getRequestByIdUseCase.Execute(requestId);
    }

    public async Task<UserBuildings> GetUserBuildingRequestsAsync(int buildingId)
    {
        return await _getUserBuildingRequests.Execute(buildingId);
    }

    public async Task UpdateRepairRequestAsync(RepairRequest repairRequest)
    {
        await _updateRepairRequestUseCase.Execute(repairRequest);
    }

    public async Task UpdateRequestNoteAsync(RequestNotes requestNote)
    {
        await _updateRequestNoteUseCase.Execute(requestNote);
    }
}